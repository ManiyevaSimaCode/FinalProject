using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.SubCategory;

public class SubCategoryPostDto
{
    public string Name { get; set; }
    public IFormFile formFile { get; set; }
    public  int CategoryGetDtoId { get; set; }
    public DateTime CreatedDate { get; set; }

}
