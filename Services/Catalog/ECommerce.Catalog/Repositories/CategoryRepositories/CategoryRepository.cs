using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;

namespace ECommerce.Catalog.Repositories.CategoryRepositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }
    }
}
