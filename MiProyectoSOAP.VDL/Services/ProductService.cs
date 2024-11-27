using MiProyectoSOAP.Contrato;
using MiProyectoEntities;
using MiProyectoVDL.Data;

namespace MiProyectoSOAP.VDL.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts() => _context.Products.ToList();

        public Product GetProductById(int id) => _context.Products.FirstOrDefault(p => p.productid == id);

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product UpdateProduct(int id, Product product)
        {
            var existingProduct = _context.Products.Find(id);
            if (existingProduct == null) return null;

            existingProduct.productname = product.productname;
            existingProduct.unitprice = product.unitprice;
            existingProduct.categoryid = product.categoryid;
            _context.SaveChanges();

            return existingProduct;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}