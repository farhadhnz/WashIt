namespace WashIt.API.Models
{
    public class WashingMode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationMinutes { get; set; }
        public string Temperature { get; set; }

    }
}