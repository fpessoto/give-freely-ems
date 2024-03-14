# Give Freely Code Challeging

<https://github.com/Give-Freely/fscodingchallenge?tab=readme-ov-file#full-stack-developer-coding-challenge-employee-management-system>

## Stack

### Backend

- .NET 8 implemented with clean arch
- Database: SQL Lite to simplify the infrastructure
- EF as ORM
- Docker + Nginx as reversed proxy

### Frontend

- NextJS 14
- Shadcn/ui as collection of re-usable components

## Running the application

Backend

```bash
cd api/GiveFreely.EMS
docker-compose up --build
```

Frontend

```bash
cd web-app
npm install
npm run dev --experimental-https
```

[Swagger](http://localhost/swagger/index.html)

[Web App](http://localhost:3000/)

## Executing automed tests

Unit test

```bash
cd api/GiveFreely.EMS
dotnet run test --project tests/GiveFreely.EMS.UnitTests
```

Integration test

```bash
dotnet run test --project tests/GiveFreely.EMS.IntegrationTests
```

Functional test

```bash
dotnet run test --project tests/GiveFreely.EMS.FunctionalTests
```
