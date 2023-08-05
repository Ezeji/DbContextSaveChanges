namespace DbContextSaveChanges.Models
{
	public class AppointmentRequest
	{
		public int RequestId { get; set; }
		public string? PatientCode { get; set; }
		public int? PatientId { get; set; }
		public string? PatientFirstName { get; set; }
		public string? PatientLastName { get; set; }
		public string? PatientPhone { get; set; }
		public int PatientGender { get; set; }
		public string? PatientEmail { get; set; }
		public string? PatientAddress { get; set; }
		public DateTime? PatientDateOfBirth { get; set; }
		public int AppointmentStatus { get; set; }
		public string? PharmacyCode { get; set; }
		public bool? IsPharmacyPaid { get; set; }
		public string? PartnerCode { get; set; }
		public int AppointmentService { get; set; }
		public decimal ServiceCharge { get; set; }
		public string? CreatedBy { get; set; }
		public int CreationMode { get; set; }
		public bool UseSortingCenter { get; set; }
		public DateTime? DateCreated { get; set; }
		public DateTime? ProcessedDate { get; set; }
		public DateTime? DateUpdated { get; set; }
		public DateTime? PickUpDate { get; set; }
		public virtual Pharmacy? PharmacyCodeNavigation { get; set; }
	}
}