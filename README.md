# DilkePass Backend API

DilkePass is a ticket booking platform that enables tourists to reserve entry tickets for tourist attractions in advance. The platform aims to simplify the booking process by allowing users to browse attractions, view pricing information, and make bookings based on their preferred visit dates. There will be an approval workflow for the approval based locations. Refund and cancellation system. Pricing logic based on type of visitors.

This repository contains the backend API built using ASP.NET Core and follows Clean Architecture principles.

> **Project Status:** Under Active Development 

---

## Overview

DilkePass is designed to provide a centralized platform for managing tourist attraction bookings.

The system allows:

* User registration and authentication
* Browsing tourist attractions
* Managing attraction pricing
* Booking tickets for future visit dates
* Tracking booking information
* Managing tourist details

The backend exposes REST APIs that will be consumed by future frontend applications.

---

## Technology Stack

* ASP.NET Core Web API
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* Clean Architecture
* Repository Pattern
* Dependency Injection

---

## Solution Architecture

The project follows Clean Architecture to maintain separation of concerns and scalability.

DilkePass
│
├── DilkePass.API
│   ├── Controllers
│   └── Configuration
│
├── DilkePass.Application
│   ├── Features
│   ├── DTOs
│   ├── Commands
│   ├── Queries
│   └── Interfaces
│
├── DilkePass.Domain
│   ├── Entities
│   ├── Enums
│   └── Common
│
├── DilkePass.Infrastructure
│   ├── Persistence
│   ├── Repositories
│   └── Services
│
└── DilkePass.sln
```


## Current Features

### Authentication

* User Login
* JWT Token Generation
* Protected API Access

### User Management

* Create User
* Retrieve User Information

### Tourist Attractions

* Create Tourist Attractions
* View Available Tourist Attractions

### Pricing Management

* Create Attraction Pricing
* Retrieve Effective Pricing

### Booking Module

* Domain models created
* Booking workflow currently under development

------------------------------------------------

## Core Business Entities

### User

Represents registered users who can access the platform and make bookings.

### Tourist Attraction

Represents a tourist destination or attraction available for booking.

### Price

Stores pricing information for attractions.

### Booking Header

Represents the overall booking transaction.

### Booking Line

Represents individual attraction bookings within a booking transaction.

--------------------------------------------------------

## Planned Workflow

1. User registers or logs in.
2. User browses available tourist attractions.
3. User selects a visit date.
4. System validates attraction availability.
5. System calculates applicable pricing.
6. User confirms booking.
7. Booking record is created.
8. Ticket information is generated for the visitor.

--------------------------------------------------------

## API Endpoints

### Authentication

| Method | Endpoint               |
| ------ | ---------------------- |
| POST   | /api/user/authenticate |

### User Management

| Method | Endpoint       |
| ------ | -------------- |
| POST   | /api/user      |
| GET    | /api/user/{id} |

### Tourist Attractions

| Method | Endpoint            |
| ------ | ------------------- |
| POST   | /api/tourattraction |
| GET    | /api/tourattraction |

### Pricing

| Method | Endpoint             |
| ------ | -------------------- |
| POST   | /api/price           |
| GET    | /api/price/effective |

> Additional booking endpoints will be introduced as development progresses.

---------------------------------------------------------------
---------------------------------------------------------------
===============================================================
## Getting Started

### Prerequisites

* Visual Studio 2022
* .NET SDK 8.0 or later
* SQL Server
* Git



-----------------------------------------------------------
### Clone Repository


git clone https://github.com/<your-username>/DilkePass.git

### Restore Dependencies

dotnet restore


### Configure Database

Update the connection string in:
appsettings.json

Example:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=DilkePassDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

---------------------------------------------------
### Run the Application

#### Using Visual Studio 2022

1. Open the solution (`DilkePass.sln`) in Visual Studio 2022.
2. Set `DilkePass.API` as the Startup Project.
3. Press **F5** or click **Start Debugging**.
4. Swagger UI will open automatically in the browser.
5. Use Swagger to test the available API endpoints.
Launch the project through VS 2022, and test the API end points through Swagger test run.

## Authentication

The application uses JWT Bearer Authentication. Implementation in progress

Include the generated token in API requests:

Authorization: Bearer <jwt-token>

---------------------------------------------------------
## Future Enhancements

* Ticket Booking APIs
* Booking Cancellation
* Booking History
* Ticket Availability Validation
* Dynamic Pricing Support
* Online Payment Integration
* Role-Based Authorization
* Audit Logging

---------------------------------------------------------------

## Development Status

The project is currently focused on establishing the core backend architecture and implementing booking-related business workflows.

Features, APIs, and database structures may evolve as development progresses.

