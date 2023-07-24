using checkingAccountAmount.Application.Interfaces;
using checkingAccountAmount.Domain.Interfaces;
using checkingAccountAmount.Domain.Model;

namespace checkingAccountAmount.Application.Services;

public class CheckingAccountAmountService : ICheckingAccountAmountService
{
    private readonly ICheckingAccountAmountRepository _repo;

    public CheckingAccountAmountService(ICheckingAccountAmountRepository repo)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(_repo));
    }

    public async Task<UserPosition> GetUserPosition()
    {
        return await _repo.GetUserPosition();
    }
}