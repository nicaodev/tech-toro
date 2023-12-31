﻿using checkingAccountAmount.Application.Interfaces;
using checkingAccountAmount.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace checkingAccountAmount.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class checkingAccountAmountController : ControllerBase
{
    private readonly ICheckingAccountAmountService _checkingAccountAmountService;

    public checkingAccountAmountController(ICheckingAccountAmountService checkingAccountAmountService)
    {
        _checkingAccountAmountService = checkingAccountAmountService ?? throw new ArgumentNullException(nameof(checkingAccountAmount));
    }

    /// <summary>
    /// Retorna saldo, investimentos e patrimônio total "mockados" para exemplo.
    /// </summary>
    /// <returns></returns>
    [HttpGet(template: "userPosition")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserPosition))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserPosition>> UserPosition()
    {
        var retorno = await _checkingAccountAmountService.GetUserPosition();

        return retorno is null ? NotFound("Registros não encontrados.") : Ok(retorno);
    }
}