using Entities.DTOs.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly SimRaDb _context;
        private readonly IActionContextAccessor _ActionContextAccessor;


        public ProductManager(IMapper mapper, IUnitOfWork unitOfWork, IWebHostEnvironment env, SimRaDb context, IActionContextAccessor actionContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _env = env;
            _context = context;
            _ActionContextAccessor = actionContextAccessor;
        }

        public async Task CreateAsync(ProductPostDto productPostDto)
        {
            var product = _mapper.Map<Product>(productPostDto);


            await _unitOfWork.ProductRepository.CreateAsync(product);
            await _unitOfWork.ProductRepository.SaveAsync();
            if (productPostDto.ParameterIds is not null)
            {
                foreach (var parameterId in productPostDto.ParameterIds)
                {
                    if (!_context.Parameters.Any(x => x.Id == parameterId))
                    {
                        _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Parameter Id is not found");
                        return;
                    }
                    _context.ProductParameters.Add(
                        new ProductParameter
                        {
                        ProductId = product.Id,
                        ParameterId = parameterId ,
                      

                        });

                }
            }

            _context.SaveChanges();
            //await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            Product product = await CheckProduct(id);
            product.isDeleted = true;
            //await _unitOfWork.SaveAsync();
        }

        public async Task<List<ProductGetDto>> GetAllAsync()
        {
            List<Product> products = await _unitOfWork.ProductRepository.GetAllAsync(c => !c.isDeleted, "ProductParameters.Parameter");
            if (products.Count is 0)
            {
                throw new NotFoundException(Messages.ProductNotFound);
            }
            return _mapper.Map<List<ProductGetDto>>(products);
        }

        public async Task<ProductGetDto> GetByIdAsync(int id)
        {
            Product product = await CheckProduct(id);
            return _mapper.Map<ProductGetDto>(product);
        }



        public async Task<ProductGetDto> GetByNameAsync(string name)
        {
            Product product = await CheckByName(name);
            return _mapper.Map<ProductGetDto>(product);

        }


        public async Task UpdateAsync(int id, ProductPostDto productPostDto)
        {
            Product product = await _unitOfWork.ProductRepository.GetAsync(c => c.Id == id && !c.isDeleted, "ProductParameters.Parameter");
            //product.ParameterIds = product.ProductParameters.Select(c => c.ParameterId).ToList();
            if (product is null)
            {
                throw new NotFoundException(Messages.ProductNotFound);
            }
            _unitOfWork.ProductRepository.Update(product);
            //await _unitOfWork.SaveAsync();
        }
        private async Task<Product> CheckProduct(int id)
        {
            Product product = await _unitOfWork.ProductRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (product is null)
            {
                throw new NotFoundException(Messages.ProductNotFound);
            }

            return product;
        }
        private async Task<Product> CheckByName(string name)
        {
            Product product = await _unitOfWork.ProductRepository.GetAsync(c => c.Name == name && !c.isDeleted);
            if (product is null)
            {
                throw new NotFoundException(Messages.ProductNotFound);
            }

            return product;
        }

      
    }
}
