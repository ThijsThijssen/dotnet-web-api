using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.DataAccess
{
    public class PostgreSqlContext: DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) :base(options)
        {
        }

        public DbSet<Patient> patients {get;set;}
        public DbSet<TodoItem> items {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}