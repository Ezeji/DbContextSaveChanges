namespace DbContextSaveChanges.Models
{
	public partial class Pharmacy
	{
		public Pharmacy()
		{
			AppointmentRequests = new HashSet<AppointmentRequest>();
		}

		public int PharmacyId { get; set; }
		public string PharmacyCode { get; set; }
		public string PhoneNumber { get; set; }
		public string ContactEmail { get; set; }
		public string ContactName { get; set; }
		public string Location { get; set; }
		public bool? IsActive { get; set; }
		public int PartnerType { get; set; }
		public DateTime? DateCreated { get; set; }
		public DateTime? DateUpdated { get; set; }
		public virtual ICollection<AppointmentRequest> AppointmentRequests { get; set; }
	}
}