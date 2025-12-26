
PM> Scaffold-DbContext "Host=localhost:54320;Database=Kashkartlogistics;Username=postgres;Password=Kashcarenet123!" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models -ContextDir . -Context ApplicationDbContext -Force

This project uses Entity Framework Core to scaffold a database context and entity classes from an existing PostgreSQL database.