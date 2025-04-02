namespace ConfigUI.Demo.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? RegistrationNo { get; set; }
        public string? VinCode { get; set; }
        public int? Year { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int OwnerId { get; set; }
    }
}
