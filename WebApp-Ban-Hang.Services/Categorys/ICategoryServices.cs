using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.Categorys
{
    public interface ICategoryServices
    {
        IEnumerable<Category> ViewAll();
        Category FindByName(string id);
        Task CreateAsSync(Category Category);
        Task UpdateAsSync(Category Category);
        Task DeleteById(string id);
        Task CreateById(string id);
    }
}
