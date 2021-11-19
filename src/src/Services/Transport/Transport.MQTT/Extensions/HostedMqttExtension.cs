using System;
using System.IO;
using System.Reflection;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet.AspNetCore.Extensions;
using Transport.MQTT.Services;

namespace Transport.MQTT.Extensions
{
    public static class HostedMqttExtension
    {
        public static void AddHostedMqttServer(this IServiceCollection services)
        {
            services
                .AddHostedMqttServer(mqttServer =>
                {
                    mqttServer.WithoutDefaultEndpoint();
                    mqttServer.WithConnectionValidator(new MqttConnectionValidatorService());
                })
                .AddMqttConnectionHandler()
                .AddConnections();
        }
    }
}