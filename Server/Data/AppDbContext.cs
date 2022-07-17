using System;
using Commander.WASM.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Commander.WASM.Server.Data
{
    public partial class AppDbContext : DbContext
    {

        public IConfiguration Configuration { get; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Command> Commands { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Command>().HasData(new Command
            {
                Id = Guid.NewGuid(),
                CommandString = "dotnet",
                Parameters = "new console",
                ParametersSummary = "Create a new console app.",
                RuntimeEnvironment = "All",
                OperatingSystem = "All"
            });
            modelBuilder.Entity<Command>().HasData(new Command
            {
                Id = Guid.NewGuid(),
                CommandString = "dotnet",
                Parameters = "new api",
                ParametersSummary = "Create a new api.",
                RuntimeEnvironment = "All",
                OperatingSystem = "All"
            });
            modelBuilder.Entity<Command>().HasData(new Command
            {
                Id = Guid.NewGuid(),
                CommandString = "dotnet",
                Parameters = "ef migrations",
                ParametersSummary = "Create a new database migration",
                RuntimeEnvironment = "All",
                OperatingSystem = "All"
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

