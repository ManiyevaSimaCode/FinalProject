using Core.Utilities.Extentions;
using Entities.DTOs.Company;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CompanyManager(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env = null)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(CompanyPostDto companyPostDto)
        {
            Company company = new Company
            {
                Name = companyPostDto.Name,
                CreatedDate = DateTime.Now,
                Description = companyPostDto.Description,
                FacebookUrl = companyPostDto.FacebookUrl,
                ImagePath = FileExtention.CreateFile(companyPostDto.formFile, _env.WebRootPath, "Assets/img/shop/brands"),
                TwitterUrl = companyPostDto.TwitterUrl,
                InstagramUrl = companyPostDto.InstagramUrl,
                LinkedinUrl = companyPostDto.LinkedinUrl

            };
            await _unitOfWork.CompanyRepository.CreateAsync(company);
            await _unitOfWork.CompanyRepository.SaveAsync();
        }
        public async Task DeleteByIdAsync(int id)
        {
            Company company = await _unitOfWork.CompanyRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (company is null)
            {
                throw new NotFoundException(Messages.CompanyNotFound);
            }
            company.isDeleted = true;
            await _unitOfWork.CompanyRepository.SaveAsync();
        }

        public async Task<List<CompanyGetDto>> GetAllAsync()
        {
            List<Company> companies = await _unitOfWork.CompanyRepository.GetAllAsync(c => !c.isDeleted,"Products");
            if (companies.Count is 0)
            {
                throw new NotFoundException(Messages.CompanyNotFound);
            }
            return _mapper.Map<List<CompanyGetDto>>(companies);
        }

        public Task<List<CompanyGetDto>> GetAllPaginateAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyGetDto> GetByIdAsync(int id)
        {
            Company company = await _unitOfWork.CompanyRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (company is null)
            {
                throw new NotFoundException(Messages.CompanyNotFound);
            }
            return _mapper.Map<CompanyGetDto>(company);
        }

        public async Task<CompanyGetDto> GetByNameAsync(string name)
        {
            Company company = await _unitOfWork.CompanyRepository.GetAsync(c => c.Name == name && !c.isDeleted);
            if (company is null)
            {
                throw new NotFoundException(Messages.CompanyNotFound);
            }

            return _mapper.Map<CompanyGetDto>(company);

        }



        public async Task UpdateAsync(int id, CompanyPostDto companyPostDto)
        {
            Company company = await _unitOfWork.CompanyRepository.GetAsync(c => c.Id == id && !c.isDeleted);
            if (company is null)
            {
                throw new NotFoundException(Messages.CompanyNotFound);
            }
            company.Description=companyPostDto.Description;
            company.Name=companyPostDto.Name;
            company.FacebookUrl = companyPostDto.FacebookUrl;
            company.TwitterUrl = companyPostDto.TwitterUrl;
            company.InstagramUrl = companyPostDto.InstagramUrl;
            company.LinkedinUrl = companyPostDto.LinkedinUrl;

            if (companyPostDto.formFile != null)
            {
                company.ImagePath = companyPostDto.formFile.CreateFile(_env.WebRootPath, "Assets/img/shop/brands");

            }//USING HELPER


            _unitOfWork.CompanyRepository.Update(company);
            await _unitOfWork.CompanyRepository.SaveAsync();



        }
    }
}
