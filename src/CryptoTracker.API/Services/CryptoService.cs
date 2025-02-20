using AutoMapper;
using CryptoTracker.API.Models;
using CryptoTracker.API.Models.DTOs;
using CryptoTracker.API.Services.Interfaces;
using Microsoft.Extensions.Options;
using CryptoTracker.API.Configuration;

namespace CryptoTracker.API.Services;

public class CryptoService : ICryptoService
{
    private readonly ICoinGeckoClient _coinGeckoClient;
    private readonly IMapper _mapper;
    private readonly ILogger<CryptoService> _logger;
    private readonly CoinGeckoSettings _settings;

    public CryptoService(
        ICoinGeckoClient coinGeckoClient, 
        IMapper mapper,
        ILogger<CryptoService> logger,
        IOptions<CoinGeckoSettings> settings)
    {
        _coinGeckoClient = coinGeckoClient;
        _mapper = mapper;
        _logger = logger;
        _settings = settings.Value;
    }

    public async Task<List<CoinDto>> SearchCoinsAsync(string query)
    {
        var result = await _coinGeckoClient.SearchCoins(query);
        return result.Coins;
    }

    public async Task<List<CoinMarketDto>> GetCoinMarketsAsync(string[] coinIds = null)
    {
        try
        {
            _logger.LogInformation("Fetching coin markets with IDs: {CoinIds}", coinIds != null ? string.Join(",", coinIds) : "null");
            var coins = await _coinGeckoClient.GetCoinMarkets(ids: coinIds, apiKey: _settings.ApiKey);
            _logger.LogInformation("Successfully fetched {Count} coins", coins?.Count ?? 0);
            return _mapper.Map<List<CoinMarketDto>>(coins);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetCoinMarketsAsync: {Message}", ex.Message);
            throw;
        }
    }
}
