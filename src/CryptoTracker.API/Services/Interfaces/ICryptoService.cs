using CryptoTracker.API.Models.DTOs;

namespace CryptoTracker.API.Services.Interfaces;

public interface ICryptoService
{
    Task<List<CoinDto>> SearchCoinsAsync(string query);
    Task<List<CoinMarketDto>> GetCoinMarketsAsync(string[] coinIds = null);  // Changed from CryptoCurrency to CoinMarketDto
}
