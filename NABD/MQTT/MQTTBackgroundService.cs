using HiveMQtt.Client.Options;
using HiveMQtt.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using NABD.Models.Domain;
using NABD.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace NABD.MQTT
{
    public class MQTTBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private HiveMQClient? _client;

        private string? _serialNumber;
        private int? _deviceId;
        private int? _heartRate;
        private int? _spo2;
        private float? _temperature;
        private DateTime _lastMessageTimestamp;

        public MQTTBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var options = new HiveMQClientOptions
            {
                Host = "b1ae13f79d82453192bb9bcfecf0b214.s1.eu.hivemq.cloud",
                Port = 8883,
                UserName = "zugzwang",
                Password = "12345678Ss",
                UseTLS = true
            };

            var options2 = new HiveMQClientOptions
            {
                Host = "fc8731aef5304f3aad37fa03be01e517.s1.eu.hivemq.cloud",
                Port = 8883,
                UserName = "finalProject",
                Password = "Fb123456",
                UseTLS = true
            };

            _client = new HiveMQClient(options);

            _client.OnMessageReceived += async (sender, args) =>
            {
                string topic = args.PublishMessage.Topic;
                string message = args.PublishMessage.PayloadAsString;
                _lastMessageTimestamp = DateTime.UtcNow;

                switch (topic)
                {
                    case "device/device_ID":
                        if (int.TryParse(message, out int parsedId))
                            _deviceId = parsedId;
                        break;

                    case "device/sensor/heart_rate":
                        if (float.TryParse(message, out float parsedHr))
                            _heartRate = (int)parsedHr;
                        break;

                    case "device/sensor/spo2":
                        if (float.TryParse(message, out float parsedSpO2))
                            _spo2 = (int)parsedSpO2;
                        break;

                    case "device/sensor/temperature":
                        var match = Regex.Match(message, @"Ambient:\s*(\d+\.?\d*)\s*°C,\s*Object:\s*(\d+\.?\d*)\s*°C");
                        if (match.Success)
                            _temperature = float.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                        break;

                    case "device/serial_No":
                        _serialNumber = message;
                        break;
                }

                // Check if all values are ready
                if (_serialNumber != null && _deviceId.HasValue && _heartRate.HasValue && _spo2.HasValue && _temperature.HasValue)
                {
                    await SaveToDatabase(
                        timestamp: _lastMessageTimestamp,
                        serialNumber: _serialNumber,
                        heartRate: _heartRate.Value,
                        spo2: _spo2.Value,
                        temperature: _temperature.Value
                    );

                    // Clear after save
                    _serialNumber = null;
                    _deviceId = null;
                    _heartRate = null;
                    _spo2 = null;
                    _temperature = null;
                }
            };

            var connectResult = await _client.ConnectAsync().ConfigureAwait(false);

            if (connectResult.ReasonCode == HiveMQtt.MQTT5.ReasonCodes.ConnAckReasonCode.Success)
            {
                await _client.SubscribeAsync("device/device_ID");
                await _client.SubscribeAsync("device/sensor/heart_rate");
                await _client.SubscribeAsync("device/sensor/spo2");
                await _client.SubscribeAsync("device/sensor/temperature");
                await _client.SubscribeAsync("device/serial_No");
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }

            await _client.DisconnectAsync().ConfigureAwait(false);
        }

        private async Task SaveToDatabase(DateTime timestamp, string serialNumber, int heartRate, int spo2, float temperature)
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Lookup the Tool by SerialNumber
            var tool = await db.Tools.FirstOrDefaultAsync(t => t.SerialNumber == serialNumber);

            var mqttData = new MQTTMessage
            {
                Topic = "aggregated",
                Message = $"HR: {heartRate}, SpO2: {spo2}, Temp: {temperature}, SN: {serialNumber}, ID: {tool.Id}",
                VitalDataTimestamp = timestamp,
                HeartRate = heartRate,
                OxygenSaturation = spo2,
                BodyTemperature = temperature,
                SerialNumber = serialNumber,
                ToolId = tool.Id
            };

            db.MQTTMessages.Add(mqttData);
            await db.SaveChangesAsync();
        }
    }
}
