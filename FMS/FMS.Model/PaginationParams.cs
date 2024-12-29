namespace FMS.Model
{
    public class PaginationParams
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; } = string.Empty;
    }
}
