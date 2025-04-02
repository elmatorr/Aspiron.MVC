using Aspiron.MVC.Contracts;
using Aspiron.MVC.Controllers;
using ConfigUI.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigUI.Controllers
{
    public class PersonController : BrowserMVCController<Person>
    {
        public PersonController(IConfigService config, ILogger<PersonController> logger, ITranslationService translation, ICacheProvider cacheProvider)
            : base(config, logger, translation, cacheProvider)
        {
        }

        public override Task<IEnumerable<Person>> FetchData(Dictionary<string, string>? queryParams)
        {
            // AI (ChatGPT) generated example data to simulate fetching data from a database
            var companyNames = new[]
            {
                "Tech Innovators Inc.",
                "Green Leaf Enterprises",
                "Quantum Solutions Ltd.",
                "Infinity Tech Corp.",
                "EcoFriendly Ventures"
            };

            var personNames = new[]
            {
                ("Alice", "Johnson"),
                ("Bob", "Smith"),
                ("Charlie", "Brown"),
                ("David", "Wilson"),
                ("Eva", "Davis"),
                ("Frank", "Miller"),
                ("Grace", "Anderson"),
                ("Hannah", "Thomas"),
                ("Ian", "Jackson"),
                ("Julia", "White"),
                ("Kevin", "Harris"),
                ("Laura", "Martin"),
                ("Michael", "Lee"),
                ("Nancy", "Walker"),
                ("Oliver", "Hall")
            };

            var random = new Random();
            var demoPersons = Enumerable.Range(1, 20).Select(i =>
            {
                if (i <= 5)
                {
                    // Create a company
                    return new Person
                    {
                        Id = i,
                        FirstName = companyNames[i - 1],
                        IsCompany = true,
                        StatusId = random.Next(1, 4) // Assuming status IDs range from 1 to 3
                    };
                }
                else
                {
                    // Create a person
                    var (firstName, lastName) = personNames[i - 6];
                    return new Person
                    {
                        Id = i,
                        FirstName = firstName,
                        LastName = lastName,
                        MiddleName = random.Next(2) == 0 ? "MiddleName" : null,
                        Birthdate = DateOnly.FromDateTime(DateTime.Now.AddYears(-random.Next(18, 60))),
                        IdNo = $"ID{random.Next(100000, 999999)}",
                        Comments = random.Next(2) == 0 ? "Some comments" : null,
                        StatusId = random.Next(1, 4) // Assuming status IDs range from 1 to 3
                    };
                }
            }).ToList();

            return Task.FromResult(demoPersons.AsEnumerable());
        }
    }
}
