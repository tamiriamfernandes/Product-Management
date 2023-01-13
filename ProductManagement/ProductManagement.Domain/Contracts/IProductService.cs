using ProductManagement.Domain.Core.Models;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Contracts
{
    public interface IProductService
    {
        Task<ReadProductDto> GetById(int id);
        Task<PaginatedList<ReadProductDto>> GetPaginated(PaginationParameterModel paginationParameterModel, string description);
        Task<int> Insert(CreateProductDto createProductDto);
        Task Update(UpdateProductDto updateProductDto);

        Task Delete(int id);
    }
}
