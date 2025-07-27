namespace Api.Models
{
    public class Product
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }
}
