using AutoMapper;
using CryptoTracker.API.Models;
using CryptoTracker.API.Models.DTOs;

namespace CryptoTracker.API.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map from Domain to DTO
        CreateMap<CryptoCurrency, CoinMarketDto>();
        
        // Map from DTO to Domain
        CreateMap<CoinMarketDto, CryptoCurrency>();
        
        // Map CoinDto
        CreateMap<CoinDto, CryptoCurrency>()
            .ForMember(dest => dest.CurrentPrice, opt => opt.Ignore())
            .ForMember(dest => dest.MarketCap, opt => opt.Ignore())
            .ForMember(dest => dest.PriceChangePercentage24h, opt => opt.Ignore())
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ThumbImage));
    }
}