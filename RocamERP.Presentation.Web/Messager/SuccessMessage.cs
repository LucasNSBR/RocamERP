using System;

namespace RocamERP.Presentation.Web.Messager
{
    public class SuccessMessage : BaseMessage
    {
        public override void ShowMessage(string body)
        {

        }

        public override void ShowMessage(string title, string body)
        {
            throw new NotImplementedException();
        }

        public override void ShowMessage(string title, string body, object parameters)
        {
            throw new NotImplementedException();
        }
    }
}