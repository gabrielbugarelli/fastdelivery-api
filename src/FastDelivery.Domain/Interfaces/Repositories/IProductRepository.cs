using FastDelivery.Domain.Entities;

namespace FastDelivery.Domain.Interfaces.Repositories;

public interface IProductRepository
{
  Task<IEnumerable<Product>> FindAllAsync();
  Task Create(Product product);
}
