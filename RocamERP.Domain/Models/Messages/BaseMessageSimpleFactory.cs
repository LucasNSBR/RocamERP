using RocamERP.Domain.FactoryInterfaces.Messages;

namespace RocamERP.Domain.Models.Messages
{
    public class BaseMessageSimpleFactory : IBaseMessageSimpleFactory
    {
        public BaseMessage CreateErrorMessage(string message)
        {
            return new ErrorMessage()
            {
                Title = message,
                MessageType = MessageType.Danger,
            };
        }

        public BaseMessage CreateInformationMessage(string message)
        {
            return new InformationMessage()
            {
                Title = message,
                MessageType = MessageType.Info,
            };
        }

        public BaseMessage CreateSuccessMessage(string message)
        {
            return new SuccessMessage()
            {
                Title = message,
                MessageType = MessageType.Success,
            };
        }

        public BaseMessage CreateWarningMessage(string message)
        {
            return new WarningMessage()
            {
                Title = message,
                MessageType = MessageType.Warning,
            };
        }
    }
}
