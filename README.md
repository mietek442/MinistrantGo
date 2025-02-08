# Ministrant Go 1.0 📱

### O Aplikacji 🎯

Witaj w Ministrant Go! 🚀 Ten projekt to kompleksowy system do zarządzania aplikacją liczącą punkty dla ministrantów. Celem jest usprawnienie liczenia punktów oraz organizacji zbiórek ministrantów, wykorzystując najnowsze i najbardziej niezawodne technologie. 🛠️📊


## Technologies in Frontend Used
- Vue + Vite ✔️
- QR CODE Scaner ✔️ 
- vue-router - for many pages ✔️ 

## Technologies in Backend Used
- ASP .NET CORE Web Api  ✔️
- .Net 9.0  ✔️
- CQRS ✔️
- Vertical Architecture ✔️
- Dotnet Entity Framework Core ✔️
- ASP.NET Core Identity in .NET 9 ✔️
- Fluent Validator (Work in progress)
- Docker ✔️
- Azure Blob Storage for Pictures ✔️
- QR CODE Generator ✔️


## Endpoints Overview
- **Users**: Login, Logout, Register
- **ScanQrCode**: Generate and scan QR code, verify QR code
- **StatisticsPoint**: User points count, total points of all users
- **Point**: Retrieve all points entries, edit points count, soft delete points
- **Duties**: Add duty, list duties, edit duties, delete duties, confirm duties by user

## How to Run

```bash
docker build -t ministrant-go-api .
docker run -p 5001:5001 ministrant-go-api
dotnet ef migrations remove
dotnet ef migrations add Init
dotnet ef database drop
dotnet ef database
```
Make sure to change the server connection when you make migration string in your, after migrations you change defaultconnection string back `appsettings.json` file from:

```json
"DefaultConnection": "Server=restauracja.database;Database=restauracja;User Id=restauracja;Password=restauracja;"
```

to:

```json
"DefaultConnection": "Server=localhost;Database=restauracja;User Id=restauracja;Password=restauracja;"
```
