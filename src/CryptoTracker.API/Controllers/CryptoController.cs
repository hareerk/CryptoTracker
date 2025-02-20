using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using CryptoTracker.API.Models;
using CryptoTracker.API.Models.DTOs;
using CryptoTracker.API.Services.Interfaces;

namespace CryptoTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CryptoController : ControllerBase
{
    private readonly ICryptoService _cryptoService;
    private readonly IMapper _mapper;
    private readonly ILogger<CryptoController> _logger;
    private readonly IWebHostEnvironment _environment;

    public CryptoController(
        ICryptoService cryptoService, 
        IMapper mapper,
        ILogger<CryptoController> logger,
        IWebHostEnvironment environment)
    {
        _cryptoService = cryptoService;
        _mapper = mapper;
        _logger = logger;
        _environment = environment;
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<CoinDto>>> SearchCoins([FromQuery] string query)
    {
        try
        {
            var results = await _cryptoService.SearchCoinsAsync(query);
            return Ok(results);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error searching coins");
            return StatusCode(500, "An error occurred while searching for coins");
        }
    }

    [HttpGet("markets")]
    public async Task<ActionResult<List<CoinMarketDto>>> GetCoinMarkets([FromQuery] string[] ids = null)
    {
        try
        {
            var results = await _cryptoService.GetCoinMarketsAsync(ids);
            return Ok(results);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching coin markets. Error details: {Message}", ex.Message);
            // Return the actual error message in development
            if (_environment.IsDevelopment())
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
            return StatusCode(500, "An error occurred while fetching coin markets");
        }
    }
}