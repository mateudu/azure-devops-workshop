using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyWebApp.Database
{
    static class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();

            var configuration = builder.Build();


            var connectionString = configuration["DatabaseConnectionString"];

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception($"'DatabaseConnectionString' setting is null/whitespace");
            }

            var dbOptionsBuilder = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer(connectionString);

            using (var dbContext = new MyDbContext(dbOptionsBuilder.Options))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
