namespace Core.Application.BaseRealizations;

public class BasePagination : BaseFilter
{
    public int? Offset { get; set; }
    public int? Limit { get; set; }
    //    public string? SortBy { get; set; }
    public bool? Descending { get; set; }
}
