

using Core.Entities.Concrete;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Favourite:ITable
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
