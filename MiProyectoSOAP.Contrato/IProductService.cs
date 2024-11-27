using MiProyectoEntities;
using System.ServiceModel;

namespace MiProyectoSOAP.Contrato
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        IEnumerable<Product> GetAllProducts();

        [OperationContract]
        Product GetProductById(int id);

        [OperationContract]
        Product CreateProduct(Product product);

        [OperationContract]
        Product UpdateProduct(int id, Product product);

        [OperationContract]
        bool DeleteProduct(int id);
    }
}