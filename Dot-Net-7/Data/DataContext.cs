using Dot_Net_7.Models;
using DotNet7.Migrations;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dot_Net_7.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        #region Migrations Command
        //dotnet ef migrations add initial
        //dotnet ef database update
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DotNet7;Trusted_Connection=true; TrustServerCertificate=true");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
