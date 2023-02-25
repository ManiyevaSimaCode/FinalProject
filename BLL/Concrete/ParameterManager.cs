using Entities.DTOs.Paginate;
using Entities.DTOs.Parameter;

namespace BLL.Concrete
{
    public class ParameterManager : IParameterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ParameterManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(ParameterPostDto parameterPostDto)
        {
            await _unitOfWork.ParameterRepository.CreateAsync(_mapper.Map<Parameter>(parameterPostDto));
            await _unitOfWork.ParameterRepository.SaveAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            Parameter parameter = await _unitOfWork.ParameterRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (parameter is null)
            {
                throw new NotFoundException(Messages.ParameterNotFound);
            }
            parameter.isDeleted = true;
            await _unitOfWork.ParameterRepository.SaveAsync();
        }

        public async Task<List<ParameterGetDto>> GetAllAsync()
        {
            List<Parameter> parameters = await _unitOfWork.ParameterRepository.GetAllAsync();
            if (parameters.Count is 0)
            {
                throw new NotFoundException(Messages.ParameterNotFound);
            }
            return _mapper.Map<List<ParameterGetDto>>(parameters);
        }

        public Task<List<PaginateDto<ParameterGetDto>>> GetAllPaginateAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task<ParameterGetDto> GetByIdAsync(int id)
        {
            Parameter parameter = await _unitOfWork.ParameterRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (parameter is null)
            {
                throw new NotFoundException(Messages.ParameterNotFound);
            }
            return _mapper.Map<ParameterGetDto>(parameter);
        }

        public async Task<ParameterGetDto> GetByNameAsync(string name)
        {
            Parameter parameter = await _unitOfWork.ParameterRepository.GetAsync(c => c.Name == name && !c.isDeleted);
            if (parameter is null)
            {
                throw new NotFoundException(Messages.ParameterNotFound);
            }

            return _mapper.Map<ParameterGetDto>(parameter);

        }

        public async Task UpdateAsync(int id, ParameterPostDto parameterPostDto)
        {
            Parameter parameter = await _unitOfWork.ParameterRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (parameter is null)
            {
                throw new NotFoundException(Messages.ParameterNotFound);
            }
            _mapper.Map(parameterPostDto, parameter);
            _unitOfWork.ParameterRepository.Update(parameter);
            await _unitOfWork.ParameterRepository.SaveAsync();



        }
    }
}
