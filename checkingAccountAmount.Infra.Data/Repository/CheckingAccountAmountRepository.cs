using checkingAccountAmount.Domain.Interfaces;
using checkingAccountAmount.Domain.Model;

namespace checkingAccountAmount.Infra.Data.Repository;

public class CheckingAccountAmountRepository : ICheckingAccountAmountRepository
{
    public async Task<UserPosition> GetUserPosition()
    {
        return new UserPosition
        {
            CheckingAccountAmount = 2034.00m,
            Positions = new List<Assets>
            {
                new Assets { Symbol = "PETR4", Amount = 10, CurrentPrice = 28.44m },
                new Assets { Symbol = "EGIE3", Amount = 30, CurrentPrice = 40.77m },
                new Assets { Symbol = "ITSA4", Amount = 20, CurrentPrice = 10m },
            }
        };
    }
}