using ElevenNoteSOAP.Models.CategoryModels;
using System.ServiceModel;

namespace ElevenNoteSOAP.Services.CategoryServices
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        Task<bool> AddCategory(CategoryCreate category);
        
        [OperationContract]
        Task<bool> EditCategory(CategoryEdit category);
        
        [OperationContract]
        Task<bool> DeleteCategory(int categoryId);
        
        [OperationContract]
        Task<List<CategoryListItem>> GetCategories();
        
        [OperationContract]
        Task<CategoryDetail> GetCategory(int id);
    }
}
