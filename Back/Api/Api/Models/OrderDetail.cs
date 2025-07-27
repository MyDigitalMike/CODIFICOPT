using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class OrderDetail
    {
        [Key]
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }

        // Propiedades de navegación
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
