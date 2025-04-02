namespace ConfigUI.Demo.Models
{
    public class Person 
    {
        public int Id { get; set; } 
        public required string FirstName { get; set; } 
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public bool IsCompany { get; set; } = false;
        public DateOnly? Birthdate { get; set; }
        public string? IdNo { get; set; }
        public string? Comments { get; set; }
        public int StatusId { get; set; }

    }

}
