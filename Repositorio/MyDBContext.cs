using Microsoft.EntityFrameworkCore;
using TechToysDominio;

namespace Repositorio
{
    public class MyDBContext : DbContext
    {
        public DbSet<Impressora> Impressora { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<MateriaPrima> MateriaPrima { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Embalagem> Embalagem { get; set; }
        public DbSet<Venda> Venda { get; set; }

        static MyDBContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var server = "localhost";
                var port = "5432";
                var username = "postgres";
                var password = "admin";
                var database = "TechToys";

                var conStr =
                    $"Host={server};Port={port};Database={database};Username={username};Password={password}";

                optionsBuilder.UseNpgsql(conStr);
            }
        }
    }
}