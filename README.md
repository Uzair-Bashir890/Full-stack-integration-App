# InventoryHub - Full Stack Integration Project

A modern inventory management system built with Blazor WebAssembly and ASP.NET Core Minimal API, demonstrating seamless front-end and back-end integration.

## Project Overview

InventoryHub is a full-stack application that showcases:
- Seamless integration between Blazor front-end and Minimal API back-end
- Efficient JSON data structures with proper typing
- Performance optimizations with caching strategies
- Error handling and debugging best practices

## Technical Stack

### Front-end (Blazor WebAssembly)
- Modern UI components with CSS Grid
- Client-side caching for performance
- Proper error handling and user feedback
- Type-safe API integration

### Back-end (ASP.NET Core Minimal API)
- Clean and efficient API endpoints
- Server-side caching with IMemoryCache
- Structured JSON responses
- Proper error handling and logging

## Features

- View product list with categories
- Real-time stock level indicators
- Efficient data caching
- Responsive grid layout
- Error handling and user feedback

## Performance Optimizations

### Front-end Optimizations
- Client-side caching with expiration
- Debounced API calls
- Proper state management
- Efficient error handling

### Back-end Optimizations
- Memory caching with sliding expiration
- Response compression
- Efficient JSON serialization
- Proper HTTP caching headers

## Development Process with GitHub Copilot

GitHub Copilot significantly improved the development process by:
- Generating boilerplate code for models and components
- Suggesting performance optimizations
- Helping with error handling patterns
- Providing type-safe implementations

### Key Contributions from Copilot
1. Generated initial integration code
2. Suggested caching implementations
3. Improved error handling patterns
4. Enhanced JSON structure
5. Optimized API endpoints

## Getting Started

1. Clone the repository
2. Navigate to the project directory
3. Run the back-end:
   ```powershell
   cd ServerApp
   dotnet run
   ```
4. Run the front-end:
   ```powershell
   cd ClientApp
   dotnet run
   ```
5. Open http://localhost:5073 in your browser

## Project Structure

```
FullStackApp/
├── ClientApp/           # Blazor WebAssembly front-end
│   ├── Pages/          # Razor components
│   ├── Shared/         # Shared components
│   └── wwwroot/        # Static files
├── ServerApp/          # ASP.NET Core Minimal API
│   ├── Models/         # Data models
│   └── Program.cs      # API endpoints and configuration
└── README.md          # Project documentation
```