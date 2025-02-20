# Crypto Tracker

A cryptocurrency tracking application built with .NET 8 backend and React frontend. This application uses the CoinGecko API to fetch real-time cryptocurrency data.

## Features

- Search cryptocurrencies
- View detailed market data
- Real-time price updates
- Clean architecture with SOLID principles
- API validation using FluentValidation
- AutoMapper for object mapping
- Swagger documentation

## Tech Stack

### Backend
- .NET 7
- ASP.NET Core Web API
- AutoMapper
- FluentValidation
- Refit for API integration
- MediatR
- Swagger/OpenAPI

### Frontend (Coming Soon)
- React
- TypeScript
- Vite
- Tailwind CSS

## Prerequisites

- .NET 7 SDK
- Node.js and npm (for frontend)
- IDE (Visual Studio, VS Code, etc.)
- CoinGecko API Key (free tier)

## Getting Started

### Backend Setup

1. Clone the repository:
```bash
git clone https://github.com/yourusername/crypto-tracker.git
cd crypto-tracker
```

2. Update the API configuration:
   - Navigate to `src/CryptoTracker.API/appsettings.json`
   - Update the CoinGecko API settings with your API key

3. Run the backend:
```bash
cd src/CryptoTracker.API
dotnet restore
dotnet run
```

The API will be available at:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001
- Swagger UI: https://localhost:5001/swagger

### Available Endpoints

- GET `/api/crypto/search?query={searchTerm}` - Search for cryptocurrencies
- GET `/api/crypto/markets?ids={coinIds}` - Get market data for specific coins

## Project Structure

```
CryptoTracker/
├── src/
│   ├── CryptoTracker.API/           # Backend .NET project
│   │   ├── Controllers/             # API Controllers
│   │   ├── Services/                # Business Logic
│   │   ├── Models/                  # Domain Models & DTOs
│   │   └── Configuration/           # App Configuration
│   │
│   └── CryptoTracker.Client/        # Frontend React project (Coming Soon)
│
└── tests/                           # Test projects
```

## Configuration

The application uses the following configuration structure in `appsettings.json`:

```json
{
  "CoinGecko": {
    "ApiKey": "YOUR_API_KEY",
    "BaseUrl": "https://api.coingecko.com/api/v3"
  }
}
```

## Error Handling

The application includes:
- Global exception handling
- Validation error responses
- Detailed logging in development mode
- Custom error messages for production

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Upcoming Features

- [ ] React frontend implementation
- [ ] Real-time price updates using SignalR
- [ ] User authentication
- [ ] Favorite cryptocurrencies
- [ ] Price alerts
- [ ] Historical price charts

## Acknowledgments

- [CoinGecko API](https://www.coingecko.com/en/api) for cryptocurrency data
- All the open-source libraries used in this project
