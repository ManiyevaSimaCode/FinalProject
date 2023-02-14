using Entities.DTOs.SubCategory;

namespace BLL.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(SubCategoryPostDto subcategoryPostDto)
        {
            await _unitOfWork.SubCategoryRepository.CreateAsync(_mapper.Map<SubCategory>(subcategoryPostDto));
            //await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            SubCategory subcategory = await _unitOfWork.SubCategoryRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (subcategory is null)
            {
                throw new NotFoundException(Messages.SubcategoryNotFound);
            }
            _unitOfWork.SubCategoryRepository.Delete(subcategory);
            //await _unitOfWork.SaveAsync();
        }

        public async Task<List<SubCategoryGetDto>> GetAllAsync()
        {
            List<SubCategory> subcategories = await _unitOfWork.SubCategoryRepository.GetAllAsync();
            if (subcategories.Count is 0)
            {
                throw new NotFoundException(Messages.SubcategoryNotFound);
            }
            return _mapper.Map<List<SubCategoryGetDto>>(subcategories);
        }

        public async Task<SubCategoryGetDto> GetByIdAsync(int id)
        {
            SubCategory subcategory = await _unitOfWork.SubCategoryRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (subcategory is null)
            {
                throw new NotFoundException(Messages.SubcategoryNotFound);
            }
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

        public async Task<List<SubCategoryGetDto>> GetCategorySubCategories(int categoryId, int subCategoryId)
        {

            var category = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == categoryId && !c.isDeleted);
            return _mapper.Map<List<SubCategoryGetDto>>(category.SubCategories.Where(s => s.Id.ToString().Contains(subCategoryId.ToString())));
        }


        public async Task UpdateAsync(int id, SubCategoryPostDto categoryPostDto)
        {
            SubCategory subcategory = await _unitOfWork.SubCategoryRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (subcategory is null)
            {
                throw new NotFoundException(Messages.SubcategoryNotFound);
            }
            _unitOfWork.SubCategoryRepository.Update(subcategory);
            //await _unitOfWork.SaveAsync();
        }
    }
}
