using DbContextSaveChanges.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextSaveChanges
{
    public class InMemoryDatabaseProvider : IDisposable
    {
        public AppWorldDbContext context { get; set; }

        public InMemoryDatabaseProvider()
        {
            var options = new DbContextOptionsBuilder<AppWorldDbContext>()
               .UseInMemoryDatabase("AppWorld_db")
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging()
               .Options;

            context = new AppWorldDbContext(options);

            //Appointment Requests
            List<AppointmentRequest> appointmentRequests = new List<AppointmentRequest>
            {
                new AppointmentRequest
                {
                    PatientFirstName = "Count",
                    PatientLastName = "Dracula",
                    ServiceCharge = 200,
                    PatientAddress = "Pennsylvania",
                    PatientEmail = "count@dracula.com",
                    PatientPhone = "PatientPhone",
                    PatientCode = "CDP10001",
                    AppointmentService = 1,
                    AppointmentStatus = 1,
                    IsPharmacyPaid = false,
                    PartnerCode = "AWPX10001",
                    PharmacyCode = "AWP10001",
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,
                    PickUpDate = DateTime.UtcNow,
                    RequestId = 1,
                    CreatedBy = "CreatedBy"
                },
                 new AppointmentRequest
                 {
                    PatientFirstName = "Countess",
                    PatientLastName = "Dracula",
                    ServiceCharge = 200,
                    PatientAddress = "Pennsylvania",
                    PatientEmail = "count@dracula.com",
                    PatientPhone = "PatientPhone",
                    PatientCode = "CSP10001",
                    AppointmentService = 2,
                    AppointmentStatus = 2,
                    IsPharmacyPaid = false,
                    PartnerCode = "AWPX10001",
                    PharmacyCode = "AWP10001",
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,
                    PickUpDate = DateTime.UtcNow,
                    RequestId = 2,
                    CreatedBy = "CreatedBy"
                 }
            };

            context.AppointmentRequests.AddRange(appointmentRequests);

            Pharmacy pharmacy = new Pharmacy
            {
                PharmacyId = 1,
                PharmacyCode = "AWPX10001",
                PartnerType = 3,
                Location = "Imo",
                PhoneNumber = "PhoneNumber",
                ContactEmail = "ContactEmail",
                ContactName = "franklin"
            };

            context.Pharmacies.Add(pharmacy);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
