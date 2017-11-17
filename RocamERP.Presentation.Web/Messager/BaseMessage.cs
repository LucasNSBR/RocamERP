using RocamERP.CrossCutting.MessagerInterfaces;

namespace RocamERP.Presentation.Web.Messager
{
    public abstract class BaseMessage : IBaseMessage
    {
        public string Title { get; protected set; }
        public string Body { get; protected set; }
        public MessageType MessageType { get; protected set; }

        public BaseMessage(string title)
        {
            Title = title;
        }

        public BaseMessage(string title, string body)
        {
            Title = title;
            Body = body;
        }

        public BaseMessage(string title, MessageType messageType) 
        {
            Title = title;
            MessageType = MessageType;
        }

        public BaseMessage(string title, string body, MessageType messageType)
        {
            Title = title;
            Body = body;
            MessageType = messageType;
        }
    }

    public enum MessageType
    {
        Success,
        Warning,
        Danger,
        Info,
        Primary
    }
}