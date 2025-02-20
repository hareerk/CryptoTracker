using System;
using System.ComponentModel.DataAnnotations;
namespace CryptoTracker.API.Models.DTOs;
public class CoinDto
{
    [Required]
    public string Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(20)]
    public string Symbol { get; set; }

    [Required]
    [Url]
    public string ThumbImage { get; set; }

    [Range(1, int.MaxValue)]
    public int MarketCapRank { get; set; }

}