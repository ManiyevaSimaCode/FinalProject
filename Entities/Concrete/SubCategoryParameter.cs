using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class SubCategoryParameter:ITable
    {
        public int Id { get; set; }
        [ForeignKey(nameof(SubCategory))]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        [ForeignKey(nameof(Parameter))]
        public int ParameterId { get; set; }
        public Parameter Parameter { get; set; }
    }
}
