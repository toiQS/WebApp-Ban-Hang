using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.ProductWarrantys
{
    public interface IProductWarrantyServices
    {
        IEnumerable<ProductWarranty> ViewAll();
        ProductWarranty FindById(string id);
        Task CreateAsSync(ProductWarranty product);
        Task DeleteByName(string id);
        Task UpdateAsSync(ProductWarranty product);
        Task UpdateById(string id);
    }
}
