using Azure.Core;
using DbContextSaveChanges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextSaveChanges.Services
{
    public class InsertMethodService
    {
        private static readonly InMemoryDatabaseProvider DatabaseProvider = new InMemoryDatabaseProvider();

        public string UseAdd()
        {
            //data to be added into the inMemory database using the method under benchmark
            List<AppointmentRequest> AllRequests = new List<AppointmentRequest>();

            for (int i = 0; i < 100; i++)
            {
                AllRequests.Add(new AppointmentRequest
                {
                    PatientFirstName = $"A{i}",
                    PatientPhone = "070",
                    PatientLastName = "B3",
                    PatientEmail = "count@dracula.com",
                    PharmacyCode = "AWP10001",
                    PartnerCode = "AWPX10002",
                    ServiceCharge = 1.00M,
                    AppointmentService = 1,
                    AppointmentStatus = 1,
                    PatientAddress = "Imo",
                    PatientCode = "AWA3",
                    CreatedBy = "franklin"
                });
            }

            foreach (var request in AllRequests)
            {
                DatabaseProvider.context.AppointmentRequests.Add(request);

                DatabaseProvider.context.SaveChanges();
            }

            return "Added data to inMemory database";
        }

        public string UseAddRange()
        {
            //data to be added into the inMemory database using the method under benchmark
            List<AppointmentRequest> AllRequests = new List<AppointmentRequest>();

            for (int i = 0; i < 100; i++)
            {
                AllRequests.Add(new AppointmentRequest
                {
                    PatientFirstName = $"A{i}",
                    PatientPhone = "070",
                    PatientLastName = "B3",
                    PatientEmail = "count@dracula.com",
                    PharmacyCode = "AWP10001",
                    PartnerCode = "AWPX10002",
                    ServiceCharge = 1.00M,
                    AppointmentService = 1,
                    AppointmentStatus = 1,
                    PatientAddress = "Imo",
                    PatientCode = "AWA3",
                    CreatedBy = "franklin"
                });
            }

            DatabaseProvider.context.AppointmentRequests.AddRange(AllRequests);

            DatabaseProvider.context.SaveChanges();

            return "Added data to inMemory database";
        }
    }
}
