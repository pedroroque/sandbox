namespace Api.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Api.Entities;

    public interface IProductsCrudServices
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> AddAsync(Product product);
        Task ReplaceAsync(Guid id, Product product);
    }

    public interface IProductsSalesReporting {

    }

    public interface IProductsInventoryReports {
        
    }
}