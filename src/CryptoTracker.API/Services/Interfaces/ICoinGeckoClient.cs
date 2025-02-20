using Refit;
using CryptoTracker.API.Models;
using CryptoTracker.API.Models.DTOs;
using Microsoft.Extensions.Options;
using CryptoTracker.API.Configuration;

namespace CryptoTracker.API.Services.Interfaces;

public interface ICoinGeckoClient
{
    [Get("/search?query={query}")]
    Task<SearchResultDto> SearchCoins(string query);

    [Get("/coins/markets")]
    Task<List<CryptoCurrency>> GetCoinMarkets(
        [Query] string vs_currency = "usd", 
        [Query] string[] ids = null, 
        [Query] string order = "market_cap_desc", 
        [Query] int? per_page = 100, 
        [Query] int? page = 1, 
        [Query] bool sparkline = false, 
        [Query] string price_change_percentage = "24h",
        [Header("x-cg-demo-api-key")] string apiKey = null);
}