using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSignalRandomGenerator
{
    class Program
    {
        public static List<Vehicle> vehicles;
        public static IConfiguration Config { get; private set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json");

            Config = builder.Build();



            GetVehicles().Wait();
            List<long> vehiclesLst = vehicles.Select(x => x.Id).ToList();

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            var timer = new System.Threading.Timer((e) =>
            {
                List<VehicleStatusDTO> vehicleStatusLst =
                    vehiclesLst.Select(x => new VehicleStatusDTO { VehicleId = x, StatusId = new Random().Next(0, 2) }).ToList();

                GenerateRandomSignals(vehicleStatusLst).Wait();
            }, null, startTimeSpan, periodTimeSpan);

            Console.ReadLine();
        }

        public static async Task GenerateRandomSignals(List<VehicleStatusDTO> vehiclesLst)
        {
            // ***Create a query that, when executed, returns a collection of tasks.  
            IEnumerable<Task<VehicleStatusDTO>> sendSignalsQuery = from vehicle in vehiclesLst select SendSignal(vehicle);

            // ***Use ToList to execute the query and start the tasks.   
            List<Task<VehicleStatusDTO>> sendSignalsTasks = sendSignalsQuery.ToList();

            // ***Add a loop to process the tasks one at a time until none remain.  
            while (sendSignalsTasks.Count > 0)
            {
                Task<VehicleStatusDTO> firstFinishedTask = await Task.WhenAny(sendSignalsTasks);

                // ***Remove the selected task from the list so that you don't
                // process it more than once.  
                sendSignalsTasks.Remove(firstFinishedTask);

                // Await the completed task.  
                VehicleStatusDTO vehicleStatus = await firstFinishedTask;
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Signal was been sent to vehicle" + vehicleStatus.VehicleId + " with status " + vehicleStatus.StatusId + " Date " + DateTime.Now.ToString());
            }
        }

        public static async Task<VehicleStatusDTO> SendSignal(VehicleStatusDTO status)
        {
            using (var client = new HttpClient())
            {
                var payload = new StringContent(JsonConvert.SerializeObject(status), Encoding.UTF8, "application/json");

                var response = client.PostAsync(Config["UpdateVehicle"], payload).Result;
            }
            return await Task<VehicleStatusDTO>.FromResult(status);
        }

        public static async Task GetVehicles()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(Config["GetVehicles"]);
                var data = response.Result;
                vehicles = string.IsNullOrEmpty(data) ?
                                default(List<Vehicle>) :
                                JsonConvert.DeserializeObject<List<Vehicle>>(data);
            }
        }
    }
}
