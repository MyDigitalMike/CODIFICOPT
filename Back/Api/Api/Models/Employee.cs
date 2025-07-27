using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Employee
    {
        [Key]
        public int Empid { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        // Propiedades de navegación
        public ICollection<Order> Orders { get; set; }
    }
}
