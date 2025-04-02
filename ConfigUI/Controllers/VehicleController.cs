using Aspiron.MVC.Contracts;
using Aspiron.MVC.Controllers;
using ConfigUI.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigUI.Controllers
{
    // Demo controller for testing purposes
    public class VehicleController : BrowserMVCController<Vehicle>
    {
        public VehicleController(IConfigService config, ILogger<VehicleController> logger, ITranslationService translation, ICacheProvider cacheProvider)
            : base(config, logger, translation, cacheProvider)
        {
        }

        public override Task<IEnumerable<Vehicle>> FetchData(Dictionary<string, string>? queryParams)
        {
            // AI (ChatGPT) generated example data to simulate fetching data from a database
            var makesAndModels = new Dictionary<string, string[]>
            {
                { "Toyota", new[] { "Corolla", "Camry", "RAV4", "Highlander", "Tacoma" } },
                { "Honda", new[] { "Civic", "Accord", "CR-V", "Pilot", "Odyssey" } },
                { "Ford", new[] { "F-150", "Escape", "Mustang", "Explorer", "Edge" } },
                { "Chevrolet", new[] { "Silverado", "Equinox", "Malibu", "Tahoe", "Traverse" } },
                { "BMW", new[] { "3 Series", "5 Series", "X3", "X5", "7 Series" } },
                { "Mercedes-Benz", new[] { "C-Class", "E-Class", "GLC", "GLE", "S-Class" } },
                { "Audi", new[] { "A3", "A4", "Q5", "Q7", "A6" } },
                { "Nissan", new[] { "Altima", "Sentra", "Rogue", "Pathfinder", "Frontier" } },
                { "Hyundai", new[] { "Elantra", "Sonata", "Tucson", "Santa Fe", "Palisade" } },
                { "Tesla", new[] { "Model S", "Model 3", "Model X", "Model Y", "Cybertruck" } }
            };

            var random = new Random();
            var demoVehicles = Enumerable.Range(1, 30).Select(i =>
            {
                var make = makesAndModels.Keys.ElementAt(random.Next(makesAndModels.Count));
                var model = makesAndModels[make][random.Next(makesAndModels[make].Length)];

                return new Vehicle
                {
                    Id = i,
                    RegistrationNo = $"ABC-{random.Next(1000, 9999)}",
                    VinCode = $"VIN{random.Next(100000, 999999)}{random.Next(10000, 99999)}",
                    Year = random.Next(2000, 2024), // Random year from 2000-2023
                    Make = make,
                    Model = model,
                    OwnerId = random.Next(1, 11) // Assigning 10 different owners
                };
            }).ToList();

            return Task.FromResult(demoVehicles.AsEnumerable());
        }
    }
}
