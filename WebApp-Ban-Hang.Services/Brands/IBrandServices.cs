using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.Brands
{
    public interface IBrandServices
    {
        IEnumerable<Brand> ViewAll();
        Brand FindById(string id);
        Task CreateAsSync(Brand brand);
        Task UpdateAsSync(Brand brand);
        Task DeleteById(string id);
        Task CreateById(string id);
    }
}
