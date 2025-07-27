namespace Api.Models
{
    public class Shipper
    {
        public int Shipperid { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        // Propiedades de navegación
        public ICollection<Order> Orders { get; set; }
    }
}
