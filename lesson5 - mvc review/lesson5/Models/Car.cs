
namespace lesson5.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public int DriverId { get; set; }
        public Person Driver { get; set; }
    }
}
