using System.Collections.Generic;
namespace CryptoTracker.API.Models.DTOs;

public class SearchResultDto
{
    public List<CoinDto> Coins { get; set; }
}

