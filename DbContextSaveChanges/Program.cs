using DbContextSaveChanges.Models;
using DbContextSaveChanges.Services;

namespace DbContextSaveChanges
{
	internal class Program
	{
		private static async Task Main(string[] args)
		{
			var a1 = new AppointmentRequest
			{
				PatientFirstName = "A1",
				PatientPhone = "070",
				PatientLastName = "B1",
				PartnerCode = "AWPX10001",
				ServiceCharge = 1.00M,
				AppointmentService = 1,
				AppointmentStatus = 1,
				PatientAddress = "Imo",
				PatientCode = "AWA1"
			};

			//faulty insert since the Partner code does not exist in the database
			var a3 = new AppointmentRequest
			{
				PatientFirstName = "A3",
				PatientPhone = "070",
				PatientLastName = "B3",
				PartnerCode = "AWPX10002",
				ServiceCharge = 1.00M,
				AppointmentService = 1,
				AppointmentStatus = 1,
				PatientAddress = "Imo",
				PatientCode = "AWA3"
			};

			var a4 = new Pharmacy
			{
				PharmacyCode = "AWPX10002",
				PartnerType = 3,
				Location = "Imo",
				PhoneNumber = "PhoneNumber",
				ContactEmail = "ContactEmail",
				ContactName = "franklin"
			};

			var a5 = new EmailQueue
			{
				EmailContent = "No content",
				EmailSubject = "No content",
				DataVariables = string.Empty,
				EmailFrom = "EmailFrom",
				EmailTo = "EmailTo",
				QueueStatus = 1,
			};

			List<AppointmentRequest> allRequests = new List<AppointmentRequest>();

			for (int i = 0; i < 1000; i++)
			{
				if (i == 500)
				{
					//simulating a bad insert here so that this insert fails
					allRequests.Add(new AppointmentRequest
					{
						PatientFirstName = $"A{i}",
						PatientPhone = "070",
						PatientLastName = "B3",
						PartnerCode = "AWPX10003",
						ServiceCharge = 1.00M,
						AppointmentService = 1,
						AppointmentStatus = 1,
						PatientAddress = "Imo",
						PatientCode = "AWA3"
					});
					continue;
				}

				allRequests.Add(new AppointmentRequest
				{
					PatientFirstName = $"A{i}",
					PatientPhone = "070",
					PatientLastName = "B3",
					PartnerCode = "AWPX10002",
					ServiceCharge = 1.00M,
					AppointmentService = 1,
					AppointmentStatus = 1,
					PatientAddress = "Imo",
					PatientCode = "AWA3"
				});
			}

            using (var conn = new AppWorldDbContext())
			{

				//conn.Partners.Add(a4);

				//conn.FulfilmentRequests.Add(a1);

				//conn.FulfilmentRequests.Add(a3);
				//conn.EmailQueue.Add(a5);

				//simulating a bad insert with just Add() that will result to data inconsistency in the database
				//which will cause an error at the 500th item during insert and further abort the operation
				foreach (var item in allRequests)
				{
                    conn.AppointmentRequests.Add(item);

                    await conn.SaveChangesAsync();
                }

				//this will achieve data consistency in the database but then with the current setup isn't ideal
				//to handle concurrent requests especially a scenario of writing and reading at same time by different
				//users which is basically as a result of the default READ_COMMITTED isolation level used by EfCore from SQL Server database
                //conn.FulfilmentRequests.AddRange(allRequests);

				//int result = await conn.SaveChangesAsync();

				//Console.WriteLine(result);
			}

			Console.WriteLine("done");
		}
	}
}