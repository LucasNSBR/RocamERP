using RocamERP.CrossCutting.MessagerInterfaces;

namespace RocamERP.Presentation.Web.Messager
{
    public abstract class BaseMessage : IBaseMessage
    {
        public abstract void ShowMessage(string body);
        public abstract void ShowMessage(string title, string body);
        public abstract void ShowMessage(string title, string body, object parameters);
    }
}