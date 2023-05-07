using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.ProductInfos
{
    public interface IProductInfoServices
    {
        IEnumerable<ProductInfo> ViewAll();
        ProductInfo FindById(int id);
        Task CreateAsSync(ProductInfo productInfo);
        Task DeleteById(int id);
        Task UpdateAsSync(ProductInfo productInfo);
        Task UpdateById(int id);
    }
}
