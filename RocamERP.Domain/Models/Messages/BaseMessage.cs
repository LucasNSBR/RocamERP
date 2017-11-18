namespace RocamERP.Domain.Models.Messages
{
    public class BaseMessage
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public MessageType MessageType { get; set; }
            
        public BaseMessage() 
        {

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