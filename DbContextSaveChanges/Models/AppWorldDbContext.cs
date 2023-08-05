using DbContextSaveChanges.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DbContextSaveChanges.Models
{
	public class AppWorldDbContext : DbContext
	{
		public AppWorldDbContext()
		{

		}

        public AppWorldDbContext(DbContextOptions<AppWorldDbContext> options)
            : base(options)
        {
        }

		//since we are using inMemory database with this current code structure,
		//we need to comment out this method when running the benchmark project and
		//uncomment back when using MS SQL Server which is the current database provider.
		//Better still, we can re-arrange the code structure to have database configuration
		//off this database context class for ease of database provider switching based on choice.
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			string connectionString = "Provide database connection string here";
			optionsBuilder.UseSqlServer(connectionString);
			optionsBuilder.LogTo(Console.WriteLine);
			optionsBuilder.EnableSensitiveDataLogging();
		}

		public virtual DbSet<Pharmacy> Pharmacies { get; set; }
		public virtual DbSet<AppointmentRequest> AppointmentRequests { get; set; }
		public virtual DbSet<EmailQueue> EmailQueue { get; set; }

		//Regenerate Models and DBContext using CodeFirst From Database
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new PharmacyConfiguration());

			modelBuilder.ApplyConfiguration(new AppointmentRequestConfiguration());

			////Ensure all dates are saved as UTC and read as UTC:
			////https://github.com/dotnet/efcore/issues/4711#issuecomment-481215673

			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				foreach (var property in entityType.GetProperties())
				{
					if (property.ClrType == typeof(DateTime))
					{
						modelBuilder.Entity(entityType.ClrType)
						 .Property<DateTime>(property.Name)
						 .HasConversion(
						  v => v.ToUniversalTime(),
						  v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
					}
					else if (property.ClrType == typeof(DateTime?))
					{
						modelBuilder.Entity(entityType.ClrType)
						 .Property<DateTime?>(property.Name)
						 .HasConversion(
						  v => v.HasValue ? v.Value.ToUniversalTime() : v,
						  v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);
					}
				}
			}
		}
	}
}
