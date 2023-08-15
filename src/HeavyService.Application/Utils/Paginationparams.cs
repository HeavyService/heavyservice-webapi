namespace HeavyService.Application.Utils;

public class Paginationparams
{
    public int PageSize { get; set; }

    public int PageNumber { get; set; }

    public Paginationparams(int pagenumber, int pagesize)
    {
        PageNumber = pagenumber;
        PageSize = pagesize;
    }

    public int SkipCount()
    {
        return (PageNumber - 1) * PageSize;
    }
}