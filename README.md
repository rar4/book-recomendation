# Book Recommendation System

Desktop book recommendation application built with C# Blazor, using the GoodBooks-10k dataset for collaborative filtering recommendations.

## Project Structure

```
book-recomendation/
│
├── Components/              # Blazor/Razor UI components
│   └── Pages/
│       └── Feed.razor       # Main feed page component
├── Data/                    # Data access layer and repositories
│   └── SQLScripts/          # Database scripts
├── Models/                  # Entity models (Book, User, Rating)
├── Properties/              # Project configuration
├── wwwroot/                 # Static assets (CSS, JS)
│
├── Program.cs               # Application entry point and service configuration
├── UserInteraction.cs       # User interaction logic and request handlers
├── Utils.cs                 # Utility functions (CSV parsing, similarity calculations)
├── appsettings.json         # Application configuration
├── bookrec.csproj           # Project file
│
└── README.md
```

## Installation

```bash
# Clone repository
git clone https://github.com/rar4/book-recomendation.git
cd book-recomendation

# Restore dependencies
dotnet restore

# Run application
dotnet run
```

**Prerequisites**: .NET 9.0 SDK, dotnet cli

## Architecture

### Core Files

**Program.cs**

- Configures minimal API server
- Registers services in dependency injection container
- Sets up middleware pipeline and routing

**UserInteraction.cs**

- Coordinates between UI layer and business logic
- Key methods: 
	- FeedEndpoint() 
	- RateEndpoint()
	- DbErrorEndpoint() - handels situation when forntend gets wrong book

**Utils.cs**

- DB interaction logic
- Key methods:
	- FillSimilarityTable() - prepares table for recomendation algorythm
	- IsbnLookup() - gets book info by ISBN from google api
	- GetRecomendedBookIsbnAndId() - recomendation algorythm


**Feed.razor**

- Primary UI component displaying book recommendations
- Handles user interactions (rating)
- Integrates with recommendation engine to fetch and display personalized results

**Models/** - Entity classes representing domain objects (Book, User, Rating, Recommendation)

**Data/** -  Data Base context and all its utilities

**SQL Scripts** - Database initialization and management scripts:

- Schema creation for books, users, ratings tables
- Creation of Recomendation table
- Actual recomending business logic

**Components/** - Reusable Blazor components (BookCard, RatingComponent, SearchBar, RecommendationList)

**wwwroot/** - Static files (stylesheets, client-side JavaScript, images)

## Technology Stack

- ASP.NET Core (C#)
- Entity Framework Core
- Blazor/Razor Pages
- GoodBooks-10k dataset (10K books, 6M ratings)
- .NET 9.0

