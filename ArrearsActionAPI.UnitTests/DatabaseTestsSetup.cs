using ArrearsActionAPI.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;

namespace ArrearsActionAPI.UnitTests
{
    [TestFixture]
    public class DatabaseTestsSetup
    {
        private IDbContextTransaction _transaction;
        protected CoreHousingContext _coreHousingContext { get; private set; }

        [SetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseNpgsql(ConnectionString());
            _coreHousingContext = new CoreHousingContext(builder.Options);

            _coreHousingContext.Database.EnsureCreated();
            _transaction = _coreHousingContext.Database.BeginTransaction();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public static string ConnectionString()
        {
            return $"Host={Environment.GetEnvironmentVariable("DB_HOST") ?? "127.0.0.1"};" +
                   $"Port={Environment.GetEnvironmentVariable("DB_PORT") ?? "5432"};" +
                   $"Username={Environment.GetEnvironmentVariable("DB_USERNAME") ?? "postgres"};" +
                   $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "mypassword"};" +
                   $"Database={Environment.GetEnvironmentVariable("DB_DATABASE") ?? "testdb"}";
        }
    }
}
