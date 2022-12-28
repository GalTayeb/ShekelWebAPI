namespace ShekelWebAPI.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int GroupCode { get; set; }
        public int FactoryCode { get; set; }
    }
}
