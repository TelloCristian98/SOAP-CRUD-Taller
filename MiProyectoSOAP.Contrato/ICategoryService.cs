using MiProyectoEntities;
using System.ServiceModel;

namespace MiProyectoSOAP.Contrato
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        IEnumerable<Category> GetAllCategories();

        [OperationContract]
        Category GetCategoryById(int id);

        [OperationContract]
        Category CreateCategory(Category category);

        [OperationContract]
        Category UpdateCategory(int id, Category category);

        [OperationContract]
        bool DeleteCategory(int id);
    }
}