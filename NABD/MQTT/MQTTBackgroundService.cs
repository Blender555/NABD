using HiveMQtt.Client;
using HiveMQtt.Client.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NABD.Data;
using NABD.Models.Domain;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NABD.MQTT
{
    public class MQTTBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private HiveMQClient? _client;

        public MQTTBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var options = new HiveMQClientOptions
            {
                Host = "fc8731aef5304f3aad37fa03be01e517.s1.eu.hivemq.cloud",
                Port = 8883,
                UserName = "finalProject",
                Password = "Fb123456",
                UseTLS = true
            };
            //var options2 = new HiveMQClientOptions
            //{
            //    Host = "b1ae13f79d82453192bb9bcfecf0b214.s1.eu.hivemq.cloud",
            //    Port = 8883,
            //    UserName = "zugzwang",
            //    Password = "12345678Ss",
            //    UseTLS = true
            //};

            _client = new HiveMQClient(options);

            _client.OnMessageReceived += async (sender, args) =>
            {
                string topic = args.PublishMessage.Topic;
                string message = args.PublishMessage.PayloadAsString;
                DateTime timestamp = DateTime.UtcNow;

                if (topic == "device/")
                {
                    // Example: "Serial: PB2503240140869, Tempe: 28.79, HeartRate: 0.0, SpO2: 0.00%"
                    var match = Regex.Match(message, @"Serial:\s*(\w+),\s*Tempe:\s*([\d.]+),\s*HeartRate:\s*([\d.]+),\s*SpO2:\s*([\d.]+)%");

                    if (match.Success)
                    {
                        string serialNumber = match.Groups[1].Value;
                        float temperature = float.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                        int heartRate = (int)float.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
                        int spo2 = (int)float.Parse(match.Groups[4].Value, CultureInfo.InvariantCulture);

                        await SaveToDatabase(timestamp, serialNumber, heartRate, spo2, temperature);
                    }
                    else
                    {
                        Console.WriteLine($"[WARN] Invalid message format: {message}");
                    }
                }
            };

            var connectResult = await _client.ConnectAsync().ConfigureAwait(false);

            if (connectResult.ReasonCode == HiveMQtt.MQTT5.ReasonCodes.ConnAckReasonCode.Success)
            {
                await _client.SubscribeAsync("device/");
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

            var tool = await db.Tools
            .Where(t => t.SerialNumber == serialNumber)
            .FirstOrDefaultAsync();


            if (tool == null)
            {
                Console.WriteLine($"[ERROR] Tool with SerialNumber '{serialNumber}' not found. MQTT message skipped.");
                return;
            }

            var mqttData = new MQTTMessage
            {
                Topic = "device",
                Message = $"HR: {heartRate}, SpO2: {spo2}, Temp: {temperature}, SN: {serialNumber}, ID: {tool.Id}",
                VitalDataTimestamp = timestamp,
                HeartRate = heartRate,
                OxygenSaturation = spo2,
                BodyTemperature = temperature,
                SerialNumber = serialNumber,
                ToolId = tool.Id // Assuming you have the ToolId from the tool object
            };

            db.MQTTMessages.Add(mqttData);
            await db.SaveChangesAsync();
        }
    }
}
