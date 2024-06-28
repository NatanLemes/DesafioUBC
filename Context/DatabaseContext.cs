using DesafioUBC.DataModel;
using DesafioUBC.Model;
using Microsoft.EntityFrameworkCore;

namespace DesafioUBC.Context
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "StudentDb");
            optionsBuilder.EnableSensitiveDataLogging();

        }

        public DbSet<StudentDataModel> Students { get; set; }
        public DbSet<UserDataModel> Users { get; set; }

    }
}
