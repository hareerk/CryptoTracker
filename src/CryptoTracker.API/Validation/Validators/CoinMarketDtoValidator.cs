using FluentValidation;
using CryptoTracker.API.Models.DTOs;

namespace CryptoTracker.API.Validation.Validators;

public class CoinMarketDtoValidator : AbstractValidator<CoinMarketDto>
{
    public CoinMarketDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .Must(BeValidName).WithMessage("Name contains invalid characters");

        RuleFor(x => x.Symbol)
            .NotEmpty()
            .MaximumLength(20)
            .Must(BeValidSymbol).WithMessage("Symbol must contain only letters and numbers");

        RuleFor(x => x.CurrentPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price cannot be negative");

        RuleFor(x => x.MarketCap)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Market cap cannot be negative");

        RuleFor(x => x.MarketCapRank)
            .GreaterThan(0)
            .WithMessage("Market cap rank must be greater than 0");

        RuleFor(x => x.Image)
            .NotEmpty()
            .Must(BeValidUrl).WithMessage("Invalid URL format");
    }

    private bool BeValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && 
               name.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-' || c == '.');
    }

    private bool BeValidSymbol(string symbol)
    {
        return !string.IsNullOrWhiteSpace(symbol) && 
               symbol.All(char.IsLetterOrDigit);
    }

    private bool BeValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}