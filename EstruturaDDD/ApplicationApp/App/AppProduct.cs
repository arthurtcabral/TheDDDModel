using ApplicationApp.Interfaces;
using Domain.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.App
{
    public class AppProduct : IProductApp
    {
        IProduct _IProduct;

        public AppProduct(IProduct IProduct) => _IProduct = IProduct;

        public async Task Add(Product product)
        {
            await _IProduct.Add(product);
        }

        public async Task Delete(Product product)
        {
            await _IProduct.Delete(product);
        }

        public async Task<Product> GetEntityById(int id)
        {
            return await _IProduct.GetEntityById(id);
        }

        public async Task<List<Product>> List()
        {
            return await _IProduct.List();
        }

        public async Task Update(Product product)
        {
            await _IProduct.Update(product);
        }
    }
}
