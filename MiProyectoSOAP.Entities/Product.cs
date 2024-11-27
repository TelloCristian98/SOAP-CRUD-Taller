namespace MiProyectoEntities
{
    public class Product
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public int categoryid { get; set; }
        public decimal unitprice { get; set; }
        public int unitsinstock { get; set; }

        public Category Category { get; set; }
    }
}