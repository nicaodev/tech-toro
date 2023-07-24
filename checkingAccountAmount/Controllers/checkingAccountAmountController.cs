using checkingAccountAmount.Application.Interfaces;
using checkingAccountAmount.Application.Services;
using checkingAccountAmount.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace checkingAccountAmount.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class checkingAccountAmountController : ControllerBase
{
    private readonly ICheckingAccountAmountService _checkingAccountAmountService;

    public checkingAccountAmountController(ICheckingAccountAmountService checkingAccountAmountService)
    {
        _checkingAccountAmountService = checkingAccountAmountService;
    }
    /// <summary>
    /// Retorna saldo, investimentos e patrimônio total "mockados" para exemplo.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<UserPosition>> UserPosition()
    {
        var retorno = await _checkingAccountAmountService.GetUserPosition();

        if (retorno is null) return NotFound("Não há Registros.");

        return Ok(retorno);
    }
}