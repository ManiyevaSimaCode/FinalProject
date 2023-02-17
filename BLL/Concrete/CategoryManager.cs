using Entities.DTOs.SubCategory;

namespace BLL.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryManager(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CategoryPostDto categoryPostDto)
    {
        await _unitOfWork.CategoryRepository.CreateAsync(_mapper.Map<Category>(categoryPostDto));
        await _unitOfWork.CategoryRepository.SaveAsync();

    }

    public async Task DeleteByIdAsync(int id)
    {
        Category category = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == id && !c.isDeleted);
        if (category is null)
        {
            throw new NotFoundException(Messages.CategoryNotFound);
        }
        _unitOfWork.CategoryRepository.Delete(category);
        await _unitOfWork.CategoryRepository.SaveAsync();
    }

    public async Task<List<CategoryGetDto>> GetAllAsync()
    {
        List<Category> categories = await _unitOfWork.CategoryRepository.GetAllAsync(c=>!c.isDeleted, "SubCategories");
        if (categories.Count is 0)
        {
            throw new NotFoundException(Messages.CategoryNotFound);
        }
        return _mapper.Map<List<CategoryGetDto>>(categories);
    }

    public async Task<CategoryGetDto> GetByIdAsync(int id)
    {
        Category category = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == id && !c.isDeleted);
        if (category is null)
        {
            throw new NotFoundException(Messages.CategoryNotFound);
        }
        return _mapper.Map<CategoryGetDto>(category);
    }

    public async Task<CategoryGetDto> GetByNameAsync(string name)
    {
        Category category = await _unitOfWork.CategoryRepository.GetAsync(c => c.Name == name && !c.isDeleted);
        if (category is null)
        {
            throw new NotFoundException(Messages.CategoryNotFound);
        }
        
        return _mapper.Map<CategoryGetDto>(category);

    }



    public async Task UpdateAsync(int id, CategoryPostDto categoryPostDto)
    {
        Category category = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == id && !c.isDeleted);
        if (category is null)
        {
            throw new NotFoundException(Messages.CategoryNotFound);
        }
        _mapper.Map(categoryPostDto, category);
         _unitOfWork.CategoryRepository.Update(category);
        await _unitOfWork.CategoryRepository.SaveAsync();



    }
}
