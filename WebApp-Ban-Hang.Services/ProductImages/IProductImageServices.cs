using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.ProductImages
{
    public interface IProductImageServices
    {
        IEnumerable<ProductImage> ViewAll();
        ProductImage FindById(int id);
        Task CreateAsSync(ProductImage image);
        Task DeleteById(int id);
        Task UpdateAsSync(ProductImage image);
        Task UpdateById(int id);
        
    }
}
