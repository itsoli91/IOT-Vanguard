using System.Threading.Tasks;
using MQTTnet.Protocol;
using MQTTnet.Server;

namespace Transport.MQTT.Services
{
    public class MqttConnectionValidatorService : IMqttServerConnectionValidator
    {
        public async Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
        {
            if (context.ClientId.Length < 10)
            {
                context.ReasonCode = MqttConnectReasonCode.ClientIdentifierNotValid;
                return;
            }

            if (context.Username != "mySecretUser")
            {
                context.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                return;
            }

            if (context.Password != "mySecretPassword")
            {
                context.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                return;
            }

            context.ReasonCode = MqttConnectReasonCode.Success;
        }
    }
}