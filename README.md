# HexaProductCatalog

## Table of Contents

- [Overview](#overview)
- [Technologies](#technologies)
- [Features](#features)
- [File Structure](#file-structure)
- [Setup](#setup)
- [Usage](#usage)
- [Contributions](#contributions)
- [License](#license)

## Overview

This project is a product catalog management system built using the Ports and Adapters (Hexagonal) architecture. It allows users to fetch products from an external API, store them in memory, and perform basic operations like adding, viewing, searching, and deleting products. The system demonstrates the separation of business logic from external systems through well-defined interfaces (ports) and their implementations (adapters).

## Technologies

- **C# 12**: Core programming language for the system.
- **.NET 8**: Framework for building the application.
- **Microsoft.Extensions.DependencyInjection**: Dependency Injection framework for managing dependencies.
- **System.Text.Json**: Library for JSON serialization and deserialization.
- **HttpClient**: Used for interacting with external APIs.
- **In-Memory Storage**: Temporary storage for products using a `List<Product>`.
- **Ports and Adapters Pattern**: Architectural pattern for isolating business logic.

## Features

- **Fetch Products from API**: Retrieves product data from an external API (`https://dummyjson.com/products`).
- **Add Products**: Stores fetched products in an in-memory repository.
- **View Products**: Displays a list of all products stored in memory.
- **Search Products**: Allows searching for products by name.
- **Delete Products**: Removes a product from the catalog by its ID.
- **Product Details**: Each product includes an ID, name, price, and photo URL.

## File Structure

```
HexaProductCatalog/
├── HexaProductCatalog.Domain/                               # Domain logic and entities
│   ├── Entities/                                            # Domain entities
│   │   └── Product.cs                                       # Product entity (Id, Name, Price, Photo)
│   ├── Interfaces/                                          # Ports (interfaces)
│   │   └── IProductRepository.cs                            # Interface for product storage
│   │   └── IProductProxy.cs                                 # Interface for external API interaction
│   └── HexaProductCatalog.Domain.csproj                     # Project file
├── HexaProductCatalog.Application/                          # Application services
│   ├── Services/                                            # Business logic services
│   │   └── ProductService.cs                                # Implementation of IProductService
│   │   └── IProductService.cs                               # Interface for product operations
│   └── HexaProductCatalog.Application.csproj                # Project file
├── HexaProductCatalog.Infrastructure/                       # Adapters (implementations of ports)
│   ├── Proxies/                                             # Adapter for external API
│   │   └── ProductProxy.cs                                  # Implementation of IProductProxy
│   ├── Repositories/                                        # Adapter for storage
│   │   └── InMemoryProductRepository.cs                     # In-memory implementation of IProductRepository
│   └── HexaProductCatalog.Infrastructure.csproj             # Project file
├── HexaProductCatalog.Presentation/                         # Console application
│   ├── Program.cs                                           # Main entry point
│   ├── DependencyInjection.cs                               # DI configuration
│   └── HexaProductCatalog.Presentation.csproj               # Project file
├── HexaProductCatalog.sln                                   # Solution file
├── README.md                                                # Project overview and setup instructions
├── .gitignore                                               # Git ignore file
└── LICENSE                                                  # Project license file (optional)
```

## Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/HexaProductCatalog.git
   cd HexaProductCatalog
   ```

2. **Ensure .NET 8 is installed:**
   - Download and install the .NET 8 SDK from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).
   - Verify installation:
     ```bash
     dotnet --version
     ```

3. **Build the project:**
   ```bash
   dotnet build HexaProductCatalog.sln
   ```

4. **Run the application:**
   ```bash
   dotnet run --project HexaProductCatalog.Presentation/HexaProductCatalog.Presentation.csproj
   ```

## Usage

1. **Fetch and Add Products:**
    - When the application starts, it automatically fetches products from `https://dummyjson.com/products` and adds them to the in-memory catalog.
    - The list of fetched products with their names, prices, and photo URLs will be displayed in the console.

2. **View All Products:**
    - After fetching, the application displays the full list of products currently stored in memory under "All products from memory:".

3. **Search for Products:**
    - The application searches for products containing "Apple" in their name and displays the results under "Searching for products with name 'Apple':".

4. **Delete a Product (optional):**
    - To test deletion, modify `Program.cs` to call `await productService.DeleteProductAsync(id)` with a specific product ID (e.g., `1`), then rerun to see the updated list.

Example output:
```
Product from API: Essence Mascara Lash Princess - 9,99
Product from API: Eyeshadow Palette with Mirror - 19,99
Product from API: Apple - 1,99
...

All products from memory:
- Essence Mascara Lash Princess - 9,99
- Eyeshadow Palette with Mirror - 19,99
- Apple - 1,99
...

Searching for products with name 'Apple':
- Apple - 1,99
```

## Contributions

Contributions are welcome! If you'd like to add features (e.g., SQLite repository, CQRS with MediatR), fix bugs, or improve the system, please feel free to fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details (if included).
