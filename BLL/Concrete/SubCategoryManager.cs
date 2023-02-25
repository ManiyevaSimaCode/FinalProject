using Core.Utilities.Extentions;
using Entities.DTOs.Paginate;
using Entities.DTOs.SubCategory;
using Entities.DTOs.SubCategoryParameter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BLL.Concrete
{
    public class SubCategoryManager :ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly SimRaDb _context;
        private readonly IActionContextAccessor _ActionContextAccessor;


        public SubCategoryManager(IMapper mapper, IUnitOfWork unitOfWork, IWebHostEnvironment env, SimRaDb context, IActionContextAccessor actionContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _env = env;
            _context = context;
            _ActionContextAccessor = actionContextAccessor;
        }

        public async Task CreateAsync(SubCategoryPostDto subcategoryPostDto)
        {
            var subcat = _mapper.Map<SubCategory>(subcategoryPostDto);
            //subcat.ParameterIds = subcategoryPostDto.ParameterIds;

            await _unitOfWork.SubCategoryRepository.CreateAsync(subcat);
            await _unitOfWork.SubCategoryRepository.SaveAsync();
            
            if (subcategoryPostDto.ParameterIds is not null)
            {
                foreach (var parameterId in subcategoryPostDto.ParameterIds)
                {
                    if (!_context.Parameters.Any(x=>x.Id== parameterId))
                    {
                        _ActionContextAccessor.ActionContext.ModelState.AddModelError("", "Parameter Id is not found");
                        return;
                    }
                    
                _context.SubCategoryParameters.Add(new SubCategoryParameter { SubCategoryId = subcat.Id, ParameterId = parameterId });

                }
            }
     
            _context.SaveChanges();
            //await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            SubCategory subcategory = await _unitOfWork.SubCategoryRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (subcategory is null)
            {
                throw new NotFoundException(Messages.SubcategoryNotFound);
            }
            subcategory.isDeleted = true;
            //await _unitOfWork.SaveAsync();
        }

        public async Task<List<SubCategoryGetDto>> GetAllAsync()
        {
            List<SubCategory> subcategories = await _unitOfWork.SubCategoryRepository.GetAllAsync(c=>!c.isDeleted , "SubCategoryParameters.Parameter");
            if (subcategories.Count is 0)
            {
                throw new NotFoundException(Messages.SubcategoryNotFound);
            }
            return _mapper.Map<List<SubCategoryGetDto>>(subcategories);
        }

        public Task<List<PaginateDto<SubCategoryGetDto>>> GetAllPaginateAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task<SubCategoryGetDto> GetByIdAsync(int id)
        {
            SubCategory subcategory = await CheckSubCategory(id);
            return _mapper.Map<SubCategoryGetDto>(subcategory);
        }

     

        public async Task<SubCategoryGetDto> GetByNameAsync(string name)
        {
            SubCategory subcategory = await _unitOfWork.SubCategoryRepository.GetAsync(c => c.Name == name && !c.isDeleted);
            if (subcategory is null)
            {
                throw new NotFoundException(Messages.SubcategoryNotFound);
            }
            return _mapper.Map<SubCategoryGetDto>(subcategory);

        }
        public async Task UpdateAsync(int id, SubCategoryPostDto subCategoryPostDto)
        {
            SubCategory subcategory = await _unitOfWork.SubCategoryRepository.GetAsync(c => c.Id == id && !c.isDeleted, "SubCategoryParameters");

            subcategory.ParameterIds = subCategoryPostDto.ParameterIds;


            subcategory.ParameterIds = subcategory.SubCategoryParameters.Select(c => c.ParameterId).ToList();
            subcategory.SubCategoryParameters.RemoveAll(sb => !subcategory.ParameterIds.Contains(sb.ParameterId));


            foreach ( var parameterId in subcategory.ParameterIds
                .Where(x=>!subcategory.SubCategoryParameters.Any(sb=>sb.ParameterId==x)))
            {
                SubCategoryParameterGetDto subCategoryParameter = new SubCategoryParameterGetDto
                {
                    ParameterId = parameterId,
                   
                    
                };
                subCategoryPostDto.SubCategoryParameters.Add(subCategoryParameter);
               
            }
            subcategory.Name = subCategoryPostDto.Name;
            subcategory.CategoryId = subCategoryPostDto.CategoryId;
            
            
            if (subcategory is null)
            {
                throw new NotFoundException(Messages.SubcategoryNotFound);
            }
            _unitOfWork.SubCategoryRepository.Update(subcategory);
            _unitOfWork.SubCategoryRepository.SaveAsync();
            //await _unitOfWork.SaveAsync();
        }
        private async Task<SubCategory> CheckSubCategory(int id)
        {
            SubCategory subcategory = await _unitOfWork.SubCategoryRepository.GetAsync(c => c.Id == id && !c.isDeleted,"Category");
            if (subcategory is null)
            {
                throw new NotFoundException(Messages.SubcategoryNotFound);
            }

            return subcategory;
        }
    }
}
