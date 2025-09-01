# DonationDemo Solution

## Overview

DonationDemo is a multi-project .NET 8 solution for managing donations. It features a Blazor Server web UI, a minimal Web API, and a layered architecture using Domain, Application, and Infrastructure projects. The solution uses Entity Framework Core with an in-memory database for demonstration and development purposes.

---

## Architecture

The solution follows a clean architecture pattern with the following projects:

- **DonationDemo.Domain**  
  Contains core domain entities (`Donation`, `PaymentMethod`) and interfaces (`IDonationRepository`).  
  - `Donation`: Represents a donation, including date, amount, payment method, notes, and validation attributes.
  - `PaymentMethod`: Represents a payment method (e.g., Card, Cash, Cheque).

- **DonationDemo.Application**  
  Contains business logic and services.  
  - `DonationService`: Provides CRUD operations and payment method retrieval, abstracting repository access.

- **DonationDemo.Infrastructure**  
  Implements data access using Entity Framework Core.  
  - `DonationDbContext`: EF Core context with seeded data for donations and payment methods.
  - `DonationRepository`: Implements `IDonationRepository` for CRUD and payment method operations.

- **DonationDemo.WebUI.Api**  
  Minimal Web API exposing donation endpoints.  
  - Endpoints for listing, retrieving, creating, updating, and deleting donations.
  - Swagger/OpenAPI enabled for API exploration.

- **DonationDemo.WebUI.Server**  
  Blazor Server web application for interactive donation management.  
  - Pages for listing, creating, editing, viewing, and deleting donations.
  - Uses QuickGrid for tabular display and pagination.
  - Dependency injection for services and repositories.

---

## Functionality

### Web API (`DonationDemo.WebUI.Api`)
- **GET /donations**: List all donations.
- **GET /donations/{id}**: Get details of a specific donation.
- **POST /donations**: Create a new donation.
- **PUT /donations/{id}**: Update an existing donation.
- **DELETE /donations/{id}**: Delete a donation.
- **Swagger UI**: Available in development for API testing.

### Blazor Web UI (`DonationDemo.WebUI.Server`)
- **Donations List**: View all donations in a table and grid format.
- **Create Donation**: Add a new donation with validation.
- **Edit Donation**: Modify existing donation details.
- **Delete Donation**: Remove a donation.
- **Donation Details**: View detailed information for a donation.
- **Payment Methods**: Display payment method names and notes.
- **Pagination**: QuickGrid supports paginated views.

### Data Layer
- **In-Memory Database**: All data is stored in-memory and seeded at startup.
- **Entities**: Donations and payment methods are modeled with validation and relationships.

---

## Getting Started

1. **Restore NuGet Packages**  
   Open the solution in Visual Studio 2022 and restore NuGet packages.

2. **Run the Solution**  
   - Start `DonationDemo.WebUI.Server` for the Blazor web UI.
   - Optionally, start `DonationDemo.WebUI.Api` for the API (Swagger available in development).

3. **Explore Functionality**  
   - Use the web UI to manage donations interactively.
   - Use Swagger UI to test API endpoints.

---

## Technologies Used

- .NET 8
- Blazor Server
- Entity Framework Core (InMemory)
- ASP.NET Core Minimal API
- Swagger / Swashbuckle
- QuickGrid

---

## ToDo

- **Add structured logging**  
  Implement structured logging (e.g., using `ILogger` and Serilog) across all layers for better diagnostics and monitoring.

- **Add comprehensive error handling throughout the solution**  
  Ensure all API endpoints, services, and UI components have robust error handling and user-friendly error messages.

- **Add more styling**  
  Enhance the UI with improved styling, consistent layouts, and responsive design.

---

## Notes

- The in-memory database is reset on each application start.
- The solution is designed for demonstration and can be extended for production use with a persistent database.

---

## License

This project is for demonstration purposes. Please adapt licensing as needed.