namespace ECommerce.Shared.Data.Entities
{
    public class Product
    {
        public Guid Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public double Price {get; set;}
        public string Code { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
    }
}
