---
name: net9-clean-architecture-agent
description:  Core 9 Clean Architecture with Blazor, CQRS, MediatR, EF Core, and RabbitMQ'
---

## Token Optimization Constraints
* **Strict Context Boundary:** Never read files outside the project layer explicitly requested by the user. Do not crawl the entire solution.
* **Terse Output:** Provide only direct code solutions and minimal explanations. No conversational fluff, greetings, or summaries.
* **No Speculative Includes:** Do not inject boilerplate using statements or external references unless explicitly requested.

## System Architecture Reference
* **Runtime:** .NET 9 (C# 13 features: enhanced params, params collections, lock object).
* **Architecture Pattern:** Clean Architecture elements with IDesign volatility-based decomposition.
* **Patterns:** Dependency Injection, CQRS with MediatR, Repository/Unit of Work omitted unless explicitly found in Infrastructure.

## Layer Isolation Rules

### 1. Access Layer
* **Location:** `SalesSystems/src/Access/`
* **Rules:** Uses EF Core, MediatR and CQRS pattern to implement access to distinct databases and expose endpoints available via GRPC.
* **Token Constraint:** When modifying Access, ignore all other layers.

### 2. Logic Layer
* **Location:** `SalesSystems/src/Logic/`
* **Rules:** Implements Business Rules and facilitatates data access for client by connnecting to the necessary access layers. Acts as the main volatility change isolation layer and implements Engines and Managers.
* **Dependencies:** Depends only on Access and Utilities. User GRPC to connect to individual access layers and exposes GRPC endpoints to clients.

### 3. Client Layer (Blazor Frontends)
* **Location:** `SalesSystems/src/Client/`
* **Tech Stack:** Blazor Web App (.NET 9 Interactive Server/WebAssembly hybrid model) and the MudBlazor library. 
* **Rules:** Implements UI/UX to allow user interaction and/or import/export facilities to interact with other systems. Connects to various logic layers via GRPC.
* **Dependencies:** Depends only on Logic and Utilities. User GRPC to connect to individual logic layers to interact with the relevant data.

### 4. Utilities Layer
* **Location:** `SalesSystems/src/Utilities/`
* **Rules:** Defined the access layers GRPC proto files, setup the logging facility, defines shared models and contracts/interfaces.
* **Dependencies:** No dependency on any other layer.

## Framework Specific Instructions

### EF Core 9 & MS SQL Server
* Use `AsNoTracking()` for queries originating from MediatR `IQuery` handlers.
* Leverage compiled queries or JSON columns if requested, utilizing native .NET 9 performance enhancements.

### Code formatting rules
* Strictly obey IDesign code formatting rules in .editorconfig

## Prohibited Actions (To Stop Token Waste)
* Do not rewrite an entire file if only fixing a single method. Use a markdown diff or output only the changed snippet.
* Do not run multi-project semantic analysis unless the user specifically initiates an agent workflow with `@net9-clean-arch-agent`.
