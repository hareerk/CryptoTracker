namespace CryptoTracker.API.Models;

public class CryptoCurrency
{
    public string Id { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public decimal CurrentPrice { get; set; }
    public decimal MarketCap { get; set; }
    public int MarketCapRank { get; set; }
    public decimal PriceChangePercentage24h { get; set; }
    public string Image { get; set; }
}