using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Converters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Npgsql;

namespace TestProject
{
    public class MyDbContext : DbContext
    {
        public static readonly LoggerFactory GlobalLoggerFactory = new LoggerFactory(new[]
        {
            new ConsoleLoggerProvider(
                (category, level)
                    => true && level >= LogLevel.Debug, true
            )
        });

        public DbSet<Chunks> Chunks { get; set; }

        public MyDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringBuilder = new NpgsqlConnectionStringBuilder();
            stringBuilder.Database = "arraytest";
            stringBuilder.Host = "localhost";
            stringBuilder.Port = 26257;
            stringBuilder.Username = "test";

            optionsBuilder.UseNpgsql(stringBuilder.ConnectionString);
            optionsBuilder.UseLoggerFactory(GlobalLoggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chunks>()
                .HasKey(c => c.Id);
        }
    }
}