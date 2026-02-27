using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;

namespace ECommerce.Catalog.Repositories.ProductRepositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }
    }
}
