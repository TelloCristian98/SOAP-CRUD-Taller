namespace MiProyectoEntities
{
    public class Category
    {
        public int categoryid { get; set; }
        public string categoryname { get; set; }
        public string? description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}