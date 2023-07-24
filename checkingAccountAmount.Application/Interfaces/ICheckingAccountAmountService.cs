using checkingAccountAmount.Domain.Model;

namespace checkingAccountAmount.Application.Interfaces;

public interface ICheckingAccountAmountService
{
    Task<UserPosition> GetUserPosition();
}