using checkingAccountAmount.Application.Services;
using checkingAccountAmount.Domain.Interfaces;
using checkingAccountAmount.Domain.Model;
using Moq;
using Shouldly;

namespace checkingAccountAmount.XUnit;

public class UnitTest1
{
    private readonly CheckingAccountAmountService _checkingAccountAmountService;
    private readonly Mock<ICheckingAccountAmountRepository> _checkingAccountAmountRepository;

    public UnitTest1()
    {
        // Configuração do mock do repositório
        _checkingAccountAmountRepository = new Mock<ICheckingAccountAmountRepository>();

        // Inicialização do serviço com o mock do repositório.
        _checkingAccountAmountService = new CheckingAccountAmountService(_checkingAccountAmountRepository.Object);
    }

    [Fact]
    public async Task Test1()
    {
        var cliente = new UserPosition
        {
            CheckingAccountAmount = 234.00m,
            Positions = new List<Assets>
            {
                new Assets { Symbol = "PETR4", Amount = 2, CurrentPrice = 28.44m },
                new Assets { Symbol = "EGIE3", Amount = 3, CurrentPrice = 40.77m }
            }
        };
        _checkingAccountAmountRepository.Setup(repo => repo.GetUserPosition()).ReturnsAsync(cliente);

        // Act
        var result = await _checkingAccountAmountService.GetUserPosition();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Positions.Count);
    }

    [Fact]
    public void Consolidated_ShouldCalculateCorrectly()
    {
        // Arrange
        var userPosition = new UserPosition
        {
            CheckingAccountAmount = 234.00m,
            Positions = new List<Assets>
            {
                new Assets { Symbol = "PETR4", Amount = 2, CurrentPrice = 28.44m },
                new Assets { Symbol = "SANB11", Amount = 3, CurrentPrice = 40.77m }
            }
        };

        // Act
        var consolidated = userPosition.Consolidated;

        // Assert
        Assert.Equal(413.19m, consolidated);
    }
}