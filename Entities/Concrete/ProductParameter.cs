using Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductParameter:ITable
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ParameterId { get; set; }
        public Parameter Parametr { get; set; }
    }
}
