using DbContextSaveChanges.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbContextSaveChanges.Configuration
{
	public class PharmacyConfiguration : IEntityTypeConfiguration<Pharmacy>
	{
		public void Configure(EntityTypeBuilder<Pharmacy> entity)
		{
			entity.HasIndex(e => e.PharmacyCode, "UQ__Pharmacies__E6792F5765B93193")
					.IsUnique();

			entity.Property(e => e.ContactEmail).IsRequired();

			entity.Property(e => e.ContactName).IsRequired();

			entity.Property(e => e.DateCreated)
				.HasColumnType("datetime")
				.HasDefaultValueSql("(getutcdate())");

			entity.Property(e => e.DateUpdated)
				.HasColumnType("datetime")
				.HasDefaultValueSql("(getutcdate())");

			entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

			entity.Property(e => e.Location).IsRequired();

			entity.Property(e => e.PharmacyCode)
				.IsRequired()
				.HasMaxLength(20);

			entity.Property(e => e.PartnerType).HasDefaultValueSql("((1))");

			entity.Property(e => e.PhoneNumber).IsRequired();
		}
	}
}