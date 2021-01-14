using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Repository.Generics;

namespace Infrastructure.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {

    }
}
