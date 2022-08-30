using static TestAPIAuth.Utils.Enums;
namespace TestAPIAuth.Models
{
    public class Request
    {
        public int Id { get;private set; } 
        public int RequestorId { get; set; }
        public int TutorId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string Details { get; set; }
        public int Price { get; set; }
        public Dificulty Dificulty { get; set; }
        public DateTime PublishDate { get; set; }
        public bool Deleted { get; set; }

    }
}
