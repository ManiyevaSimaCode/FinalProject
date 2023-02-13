
using Core.Entities.Concrete;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Review:ITable
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Rating rating { get; set; }
        public string Comment { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }


    public enum Rating
    {
        Awful = 1,
        Bad = 2,
        Medium = 3,
        Good = 4,
        Awesome = 5

    }
}


