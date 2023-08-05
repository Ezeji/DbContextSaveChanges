using DbContextSaveChanges.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbContextSaveChanges.Configuration
{
	public class AppointmentRequestConfiguration : IEntityTypeConfiguration<AppointmentRequest>
	{
		public void Configure(EntityTypeBuilder<AppointmentRequest> entity)
		{
			entity.HasKey(e => e.RequestId)
					.HasName("PK__tmp_ms_x__33A8517A6D3F3C52");

			entity.Property(e => e.CreatedBy)
				.IsRequired()
				.HasDefaultValueSql("('')");

			entity.Property(e => e.CreationMode).HasDefaultValueSql("((1))");

			entity.Property(e => e.DateCreated)
				.HasColumnType("datetime")
				.HasDefaultValueSql("(getutcdate())");

			entity.Property(e => e.DateUpdated)
				.HasColumnType("datetime")
				.HasDefaultValueSql("(getutcdate())");

			entity.Property(e => e.PatientFirstName).IsRequired();

			entity.Property(e => e.PatientPhone).IsRequired();

			entity.Property(e => e.PatientCode).IsRequired();

			entity.Property(e => e.PatientGender).HasDefaultValueSql("((3))");

			entity.Property(e => e.AppointmentService).HasDefaultValueSql("((1))");

			entity.Property(e => e.AppointmentStatus).HasDefaultValueSql("((1))");

			entity.Property(e => e.IsPharmacyPaid).HasDefaultValueSql("((0))");

			entity.Property(e => e.PartnerCode)
				.IsRequired()
				.HasMaxLength(20);

			entity.Property(e => e.PickUpDate)
				.HasColumnType("datetime")
				.HasDefaultValueSql("(getutcdate())");

			entity.Property(e => e.ServiceCharge)
				.HasColumnType("decimal(19, 2)")
				.HasDefaultValueSql("((0.00))");

			entity.Property(e => e.PatientDateOfBirth).HasColumnType("date");

			entity.Property(e => e.UseSortingCenter).HasDefaultValueSql("((0))");

			entity.HasOne(d => d.PharmacyCodeNavigation)
				   .WithMany(p => p.AppointmentRequests)
				   .HasPrincipalKey(p => p.PharmacyCode)
				   .HasForeignKey(d => d.PartnerCode)
				   .OnDelete(DeleteBehavior.ClientSetNull)
				   .HasConstraintName("FK__Fulfilmen__Partn__3F865F66");
		}
	}
}