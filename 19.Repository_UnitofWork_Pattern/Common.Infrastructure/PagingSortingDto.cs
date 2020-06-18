

namespace Common.Infrastructure
{
    public class PagingSortingDto
    {
        public int Offset { get; set; } = 1;
        public int? Limit { get; set; } = 5;
        public string SortDirection { get; set; } = "ascending"; // descending
        public string SortField { get; set; } = "Id";
    }
}
