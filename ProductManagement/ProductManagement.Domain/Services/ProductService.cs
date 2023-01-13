using AutoMapper;
using ProductManagement.Domain.Contracts;
using ProductManagement.Domain.Core.Contracts.Repositories;
using ProductManagement.Domain.Core.Contracts.UnitOfWork;
using ProductManagement.Domain.Core.Models;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IRepository<Product> productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productRepository= productRepository;
            _mapper= mapper;
            _unitOfWork= unitOfWork;
        }

        public async Task<ReadProductDto> GetById(int id)
        {

            var result = await _productRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (result is null)
                return null;

            return _mapper.Map<ReadProductDto>(result);
        }

        public async Task<PaginatedList<ReadProductDto>> GetPaginated(PaginationParameterModel paginationParameterModel, string description)
        {
            var result = await _productRepository.GetPaginatedAsync(x => x.Description.Contains(description),
                                                                    paginationParameterModel.page,
                                                                    paginationParameterModel.limit);

            if (result is null)
                return null;

            var products = _mapper.Map<IEnumerable<ReadProductDto>>(result.Items);

            return new PaginatedList<ReadProductDto>(products, result.Total, result.Page, result.PageSize);
        }

        public async Task<int> Insert(CreateProductDto createProductDto)
        {
            if (createProductDto.DateFabrication < createProductDto.DateValidity)
                throw new Exception("Data de Fabricação é menor que a de Validade");

            var entity = _mapper.Map<Product>(createProductDto);
            entity.ActiveProduct(true);

            var result = await _productRepository.AddAsync(entity);
            
            await _unitOfWork.Commit();

            return result.Id;
        }

        public async Task Update(UpdateProductDto updateProductDto)
        {
            if (updateProductDto.DateFabrication < updateProductDto.DateValidity)
                throw new Exception("Data de Fabricação é menor que a de Validade");

            var entity = _mapper.Map<Product>(updateProductDto);

            _productRepository.Update(entity);

            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            var entity = await _productRepository.FirstOrDefaultAsync(x => x.Id == id);

            entity.ActiveProduct(false);

            await _unitOfWork.Commit();
        }
    }
}
