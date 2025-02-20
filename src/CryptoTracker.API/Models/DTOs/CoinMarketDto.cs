using System.ComponentModel.DataAnnotations;

namespace CryptoTracker.API.Models.DTOs;

public class CoinMarketDto
{
    [Required]
    public string Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Symbol { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Range(0, double.MaxValue)]
    public decimal CurrentPrice { get; set; }

    [Range(0, double.MaxValue)]
    public decimal MarketCap { get; set; }

    [Range(1, int.MaxValue)]
    public int MarketCapRank { get; set; }

    public decimal PriceChangePercentage24h { get; set; }

    [Required]
    [Url]
    public string Image { get; set; }
}