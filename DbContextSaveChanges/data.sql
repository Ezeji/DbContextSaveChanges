CREATE TABLE [dbo].[EmailQueue]
(
	[EmailQueueId] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    [EmailFrom] NVARCHAR(MAX) NULL, 
    [SenderId] NVARCHAR(MAX) NULL,
    [EmailTo] NVARCHAR(MAX) NOT NULL, 
    [EmailSubject] NVARCHAR(MAX) NULL, --can be NULL if TemplateId is set
    [EmailContent] NVARCHAR(MAX) NULL, --can be NULL if TemplateId is set
    [EmailProvider] INT NOT NULL, -- 1: Gmail, 2- Sendgrid, 3-Mailchimp e.t.c
    [QueueStatus] INT DEFAULT ((1)) NOT NULL, -- 1: Queued, 2-Sent, 3-Delivered
    [DeliveryReport] NVARCHAR(MAX) NULL,
    [TemplateId] NVARCHAR(MAX) NULL, --for sendgrid and gmail provider(EmailTemplates table). If empty for sendgrid, then it's for contact update
    [DataVariables] NVARCHAR(MAX) NULL, -- JSON string that can be parsed into an object and be used in Sendgrid and Gmail
    [RedundantMailList] NVARCHAR(MAX) NULL, -- JSON string that can be parsed into an array .
    [DateCreated] DATETIME NULL DEFAULT (getutcdate()), 
    [DateUpdated] DATETIME NULL DEFAULT (getutcdate())
)


CREATE TABLE [dbo].[AppointmentRequests]
(
	[RequestId] INT NOT NULL IDENTITY(1, 1)  PRIMARY KEY,
    [PatientCode] NVARCHAR(MAX) NOT NULL, --from the provider
    [PatientId] INT NULL, -- From the proivider
    [PatientFirstName] NVARCHAR(MAX) NOT NULL,
    [PatientLastName] NVARCHAR(MAX) NULL,
    [PatientPhone] NVARCHAR(MAX) NOT NULL,
    [PatientGender] INT NOT NULL DEFAULT((3)), -- 1: Female, 2: Male, 3: Others
    [PatientEmail] NVARCHAR(MAX) NULL,
    [PatientAddress] NVARCHAR(MAX) NULL,
    [PatientDateOfBirth] DATE NULL,
    [AppointmentStatus] INT NOT NULL DEFAULT ((1)), --1-pending, 2-booked, 3-cancelled, 4-completed
    [PharmacyCode] NVARCHAR(MAX) NULL,
    [PharmacyName] NVARCHAR(MAX) NULL,
    [IsPharmacyPaid] BIT NULL DEFAULT ((0)),
    [PartnerCode] NVARCHAR(20) NOT NULL,
    [PartnerName] NVARCHAR(MAX)  NULL,
    [AppointmentService] INT NOT NULL DEFAULT((1)), ---1;Telemedicine, 2-Acute, 3-Chronic e.t.c
    [ServiceCharge] DECIMAL(19, 2) NOT NULL DEFAULT ((0.00)),
    [CreatedBy] NVARCHAR(MAX) NOT NULL DEFAULT(''), -- login Id of who created the appointment
    [AssignedTo] NVARCHAR(MAX) NULL, -- the CS agent working on it
    [CreationMode] INT NOT NULL DEFAULT((1)), -- enum 1: Support, 2-Partner API, 3-Pharmacy App e.t.c
    [Diagnosis] NVARCHAR(MAX) NULL,
    [Notes] NVARCHAR(MAX) NULL,
    [InternalNotes] NVARCHAR(MAX) NULL,
    [ProcessedDate] DATETIME NULL,
    [PreAuthorizationCode] NVARCHAR(MAX) NULL,
    [UseSortingCenter] BIT NULL DEFAULT((0)),
    [DateCreated] DATETIME NULL DEFAULT (getutcdate()), 
    [DateUpdated] DATETIME NULL DEFAULT (getutcdate()),
    [PickUpDate] DATETIME NULL DEFAULT (getutcdate()),
    [PickUpCode] NVARCHAR(MAX) NULL,
    FOREIGN KEY ([PharmacyCode]) REFERENCES [dbo].[Pharmacies]([PharmacyCode])
)


CREATE TABLE [dbo].[Pharmacies]
(
	[PharmacyId] INT NOT NULL IDENTITY(1, 1)  PRIMARY KEY,
	[PharmacyCode] NVARCHAR(20) NOT NULL UNIQUE,
	[PharmacyName] NVARCHAR(MAX) NOT NULL,
    [PhoneNumber] NVARCHAR(MAX) NOT NULL,
    [ContactEmail] NVARCHAR(MAX) NOT NULL,
    [SupportEmail] NVARCHAR(MAX) NULL,
    [ContactName] NVARCHAR(MAX) NOT NULL,
    [Location] NVARCHAR(MAX) NOT NULL,
    [StateOfResidence] NVARCHAR(MAX) NULL,
    [Lga] NVARCHAR(MAX) NULL,
    [Area] NVARCHAR(MAX) NULL,
    [StreetName] NVARCHAR(MAX) NULL,
    [IsActive] BIT NULL DEFAULT ((1)),
    [PharmacyType] INT NOT NULL DEFAULT ((1)), -- 1-AgentPharmacy, 2-Company
    [LogoUrl] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME NULL DEFAULT (getutcdate()),
    [DateUpdated] DATETIME NULL DEFAULT (getutcdate()),
)
