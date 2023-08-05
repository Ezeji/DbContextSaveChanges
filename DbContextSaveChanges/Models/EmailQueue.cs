namespace DbContextSaveChanges.Models
{
	public partial class EmailQueue
	{
		public int EmailQueueId { get; set; }
		public string? EmailTo { get; set; }
		public string? EmailFrom { get; set; }
		public string? SenderId { get; set; }
		public string? EmailSubject { get; set; }
		public string? EmailContent { get; set; }
		public int EmailProvider { get; set; }
		public int QueueStatus { get; set; }
		public string? DeliveryReport { get; set; }
		public string? TemplateId { get; set; }
		public string? RedundantMailList { get; set; } //should contain a list of templates
		public string? DataVariables { get; set; }
		public DateTime? DateCreated { get; set; }
		public DateTime? DateUpdated { get; set; }
	}
}