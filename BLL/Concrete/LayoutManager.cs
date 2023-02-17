namespace BLL.Concrete
{
    public class LayoutManager : ILayoutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LayoutManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryGetDto>> GetCategorySubCategories()
        {
          
                List<Category> categories = await _unitOfWork.CategoryRepository.GetAllAsync(c => !c.isDeleted, "SubCategories");
                if (categories.Count is 0)
                {
                    throw new NotFoundException(Messages.CategoryNotFound);
                }
                return _mapper.Map<List<CategoryGetDto>>(categories);
            
        }
    }
}
