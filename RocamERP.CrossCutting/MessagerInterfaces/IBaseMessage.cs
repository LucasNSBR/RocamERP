namespace RocamERP.CrossCutting.MessagerInterfaces
{
    public interface IBaseMessage
    {
        void ShowMessage(string body);
        void ShowMessage(string title, string body);
        void ShowMessage(string title, string body, object parameters);
    }
}
