using HiveMQtt.Client.Options;
using HiveMQtt.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using NABD.Models.Domain;
using NABD.Data;
using Microsoft.EntityFrameworkCore;

namespace NABD.MQTT
{
    public class MQTTBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private HiveMQClient? _client;

        private readonly Dictionary<string, MQTTMessage> _deviceCache = new();

        public MQTTBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var options = new HiveMQClientOptions()
            {
                Host = "b1ae13f79d82453192bb9bcfecf0b214.s1.eu.hivemq.cloud",
                Port = 8883,
                UserName = "zugzwang",
                Password = "12345678Ss",
                UseTLS = true
            };

            _client = new HiveMQClient(options);

            _client.OnMessageReceived += async (sender, args) =>
            {
                string topic = args.PublishMessage.Topic;
                string payload = args.PublishMessage.PayloadAsString;
                string sessionId = "default"; // Replace with actual session ID if needed
                DateTime timestamp = DateTime.UtcNow;

                if (!_deviceCache.ContainsKey(sessionId))
                    _deviceCache[sessionId] = new MQTTMessage();

                var data = _deviceCache[sessionId];
                data.Topic = topic;
                data.VitalDataTimestamp = timestamp;

                switch (topic)
                {
                    case "device/device_ID":
                        data.Message = $"ID: {payload}";
                        break;
                    case "device/serial_No":
                        data.SerialNumber = payload;
                        break;
                    case "device/sensor/temperature":
                        var tempMatch = Regex.Match(payload, @"Ambient: (\d+\.?\d*) °C, Object: (\d+\.?\d*) °C");
                        if (tempMatch.Success)
                        {
                            data.BodyTemperature = float.Parse(tempMatch.Groups[2].Value);
                        }
                        break;
                    case "device/sensor/heart_rate":
                        var hrMatch = Regex.Match(payload, @"Heart rate: (\d+\.?\d*) bpm, SpO2: (\d+\.?\d*)%");
                        if (hrMatch.Success)
                        {
                            data.HeartRate = int.Parse(hrMatch.Groups[1].Value);
                            data.OxygenSaturation = int.Parse(hrMatch.Groups[2].Value);
                        }
                        break;
                    case "device/sensor/spo2":
                        if (int.TryParse(payload, out int spo2Val))
                            data.OxygenSaturation = spo2Val;
                        break;
                }

                if (!string.IsNullOrWhiteSpace(data.SerialNumber) &&
                    data.HeartRate.HasValue && data.OxygenSaturation.HasValue && data.BodyTemperature.HasValue)
                {
                    data.Message = $"SN: {data.SerialNumber}, HR: {data.HeartRate}, SpO2: {data.OxygenSaturation}, Temp: {data.BodyTemperature}";
                    await SaveDeviceDataAsync(data);
                    _deviceCache.Remove(sessionId);
                }
            };

            var connectResult = await _client.ConnectAsync().ConfigureAwait(false);

            if (connectResult.ReasonCode == HiveMQtt.MQTT5.ReasonCodes.ConnAckReasonCode.Success)
            {
                await _client.SubscribeAsync("device/device_ID");
                await _client.SubscribeAsync("device/serial_No");
                await _client.SubscribeAsync("device/sensor/temperature");
                await _client.SubscribeAsync("device/sensor/heart_rate");
                await _client.SubscribeAsync("device/sensor/spo2");
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(10000, stoppingToken);
            }

            await _client.DisconnectAsync().ConfigureAwait(false);
        }

        private async Task SaveDeviceDataAsync(MQTTMessage message)
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var tool = await db.Tools.FirstOrDefaultAsync(t => t.SerialNumber == message.SerialNumber);
            if (tool == null)
            {
                Console.WriteLine($"Tool not found with SerialNumber = {message.SerialNumber}");
                return;
            }

            message.ToolId = tool.Id;

            db.MQTTMessages.Add(message);
            await db.SaveChangesAsync();
        }
    }
}
