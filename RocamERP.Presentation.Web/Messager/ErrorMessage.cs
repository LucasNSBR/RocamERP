namespace RocamERP.Presentation.Web.Messager
{
    public class ErrorMessage : BaseMessage
    {
        public ErrorMessage(string title) : base(title)
        {
        }

        public ErrorMessage(string title, string body) : base(title, body)
        {
        }

        public ErrorMessage(string title, MessageType messageType) : base(title, messageType)
        {
        }

        public ErrorMessage(string title, string body, MessageType messageType) : base(title, body, messageType)
        {
        }
    }
}