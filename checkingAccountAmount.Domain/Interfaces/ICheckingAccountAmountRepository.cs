using checkingAccountAmount.Domain.Model;

namespace checkingAccountAmount.Domain.Interfaces;

public interface ICheckingAccountAmountRepository
{
    Task<UserPosition> GetUserPosition();
}