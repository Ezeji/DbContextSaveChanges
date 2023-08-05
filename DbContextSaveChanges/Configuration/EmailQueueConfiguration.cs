using DbContextSaveChanges.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbContextSaveChanges.Configuration
{
	public class EmailQueueConfiguration : IEntityTypeConfiguration<EmailQueue>
	{
		public void Configure(EntityTypeBuilder<EmailQueue> entity)
		{
			entity.ToTable("EmailQueue");

			entity.Property(e => e.DateCreated)
				.HasColumnType("datetime")
				.HasDefaultValueSql("(getutcdate())");

			entity.Property(e => e.DateUpdated)
				.HasColumnType("datetime")
				.HasDefaultValueSql("(getutcdate())");

			entity.Property(e => e.EmailTo).IsRequired();

			entity.Property(e => e.QueueStatus).HasDefaultValueSql("((1))");
		}
	}
}