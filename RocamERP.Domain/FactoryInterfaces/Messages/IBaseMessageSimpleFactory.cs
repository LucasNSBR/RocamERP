using RocamERP.Domain.Models.Messages;

namespace RocamERP.Domain.FactoryInterfaces.Messages
{
    public interface IBaseMessageSimpleFactory
    {
        BaseMessage CreateSuccessMessage(string message);
        BaseMessage CreateErrorMessage(string message);
        BaseMessage CreateInformationMessage(string message);
        BaseMessage CreateWarningMessage(string message);
    }
}
