namespace TestAPIAuth.Models
{
    public class Filter
    {
        public int? page { get; set; }
        public int? pageSize { get; set; }
        public int[]? category { get; set; }
        public int[]? dificulty { get; set; }
        public string? orderType { get; set; }

        public string? orderBy { get; set; }
    }
}
