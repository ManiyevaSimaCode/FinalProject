using Entities.Abstract;
using Entities.DTOs.Parameter;
using Entities.DTOs.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class ProductParameter:ITable
    {
        public int Id { get; set; }
        public string Value { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Parameter))]
        public int ParameterId { get; set; }
        public Parameter Parameter { get; set; }

    }
}
