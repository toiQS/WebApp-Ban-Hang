using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Services.Categorys
{
    public interface ICategoryServices
    {
        IEnumerable<Category> ViewAll();
        Category FindById(int id);
        Task CreateAsSync(Category Category);
        Task UpdateAsSync(Category Category);
        Task DeleteById(int id);
        Task CreateById(int id);
    }
}
