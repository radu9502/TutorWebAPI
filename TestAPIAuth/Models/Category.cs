namespace TestAPIAuth.Models
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool Deleted { get; set; }
    }
}
