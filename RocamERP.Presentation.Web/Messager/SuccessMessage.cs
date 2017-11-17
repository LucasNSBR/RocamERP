namespace RocamERP.Presentation.Web.Messager
{
    public class SuccessMessage : BaseMessage
    {
        public SuccessMessage(string title) : base(title)
        {
        }

        public SuccessMessage(string title, string body) : base(title, body)
        {
        }

        public SuccessMessage(string title, MessageType messageType) : base(title, messageType)
        {
        }

        public SuccessMessage(string title, string body, MessageType messageType) : base(title, body, messageType)
        {
        }
    }
}