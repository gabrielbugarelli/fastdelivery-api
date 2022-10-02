using FastDelivery.Domain.Entities;
using FastDelivery.Domain.Interfaces.Repositories;
using FastDelivery.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FastDelivery.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
  private readonly ApplicationDbContext _applicationDbContext;

  public ProductRepository(ApplicationDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async Task Create(Product product)
  {
    await _applicationDbContext.Products.AddAsync(product);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<IEnumerable<Product>> FindAllAsync()
  {
    var products = await _applicationDbContext.Products
      .Where(product => product.Active == true)
      .ToListAsync();

    return products;
  }
}