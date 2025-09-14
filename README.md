# AIUB Shuttle Management System

AIUB Shuttle Management System is a C# project (see the repository for exact framework and project files) created to manage shuttle schedules, routes, drivers, and student bookings for the American International University — Bangladesh (AIUB). This README provides setup, structure, and development guidance for anyone who wants to run, inspect, or contribute to the project.

## Table of contents

- Project overview
- Features
- Technologies
- Prerequisites
- Setup and run
- Configuration
- Database
- Project structure
- Running tests
- Contributing
- Troubleshooting
- License & contact

## Project overview

This repository contains the source code and resources for a Shuttle Management System built in C#. The default branch is `Final-Project`. The project aims to provide an internal tool for AIUB to:

- Create and manage shuttle routes and stops
- Schedule shuttle runs
- Register and manage drivers
- Allow students and staff to view schedules and book rides
- Provide admin interfaces for reports and monitoring

Note: The repository metadata lists C# as the primary language; inspect the solution (.sln) and .csproj files for the exact target framework (for example .NET 6/7/8).

## Features

- Route and stop management
- Driver and vehicle records
- Schedule creation and editing
- Student/staff registration and booking
- Admin dashboard and reporting

## Technologies

- C# (see solution files for exact target framework)
- Likely ASP.NET (MVC or Web API) or a desktop UI — check the project type in the .sln/.csproj files
- SQL Server / SQLite / other relational DB (check configuration)

## Prerequisites

- Git
- .NET SDK (check .sln/.csproj for the required version; .NET 6+ recommended)
- Visual Studio (or VS Code with C# extensions) if you want an IDE
- A relational database engine if the project requires one (SQL Server, SQLite, etc.)

## Setup and run

1. Clone the repository:

   git clone https://github.com/Mahbubul-Islam/AIUB_SHUTTLE_MANAGEMENT_SYSTEM.git
   cd AIUB_SHUTTLE_MANAGEMENT_SYSTEM

2. Switch to the Final-Project branch (this repository's default branch):

   git checkout Final-Project

3. Inspect the solution and project files to determine the target framework and project to run. For example, list files in the repo root and look for a `*.sln` file or project folders (Controllers, Views, etc.).

4. Restore dependencies and build with the dotnet CLI (replace `YourProject.csproj` with the actual project file if necessary):

   dotnet restore
   dotnet build

5. Run the project (if an ASP.NET project, run the web project):

   dotnet run --project path/to/YourWebProject

6. Open the browser at the address shown in the console (usually https://localhost:5001 or http://localhost:5000).

If the project is a desktop application (WinForms/WPF), open the .sln in Visual Studio and run from the IDE.

## Configuration

- Check `appsettings.json` or other configuration files for database connection strings and app settings.
- If the project uses environment-specific settings, provide `appsettings.Development.json` or set environment variables locally.

Example: edit appsettings.json and update the connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ShuttleDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

## Database

- If the project uses Entity Framework migrations, look for a `Migrations` folder and use `dotnet ef database update` after restoring tools.
- If there is a SQL script or seed data in a `database/` or `scripts/` folder, run it against your local DB.
- If you are unsure which database is required, open `appsettings.json` or `.env` to find the provider.

## Project structure (typical)

- / (root)
  - README.md (this file)
  - *.sln - Visual Studio solution file (if present)
  - /src or /ProjectName - project folders
  - /Controllers - MVC controllers (if web)
  - /Models - domain models
  - /Views - Razor views (if web)
  - /Data - EF Core DbContext and migrations
  - /Services - business logic
  - /wwwroot - static files (if web)
  - /tests - unit/integration tests

Adjust the structure above to match the repository contents. If you need, run a quick file listing to see exact folder names.

## Running tests

- If the repository contains a `tests` project, run:

  dotnet test

- Otherwise, check for instructions or test projects in the repository.

## Contributing

Contributions are welcome. To contribute:

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/your-feature`
3. Make changes and add tests where appropriate
4. Commit and push: `git push origin feature/your-feature`
5. Create a pull request describing your changes

Please follow the repository's code style and include clear commit messages.

## Troubleshooting

- Build errors: check the target framework in `*.csproj` files and install the corresponding SDK.
- Database errors: confirm the connection string and ensure the DB server is running; apply migrations or run any provided SQL seed scripts.
- Missing packages: run `dotnet restore` and ensure your NuGet feed is accessible.

## License

No license is specified in the repository metadata. If you own this project, consider adding a license (e.g., MIT) to clarify usage terms.

## Contact

Repository owner: Mahbubul-Islam

If you need help running the project or want me to add more targeted instructions (for example, I can inspect the solution and create exact commands for running the web project and database migrations), tell me and I will inspect the repository files and update this README accordingly.