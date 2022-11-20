using System.ComponentModel.DataAnnotations;
public class DTOJobListRequest
{
    [Required(AllowEmptyStrings = true)]
    public string Q { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Page number should be greater than 1")]
    public int PageNo { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Page size should be greater than 1")]
    public int PageSize { get; set; }
    public int LocationId { get; set; }
    public int DepartmentId { get; set; }
}

public class DTOJobListResponse
{
    public int Total { get; set; }
    public List<DTOJobListJob> Data { get; set; }
}

public class DTOJobListJob
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public string Department { get; set; }
    public DateTime PostedDate { get; set; }
    public DateTime ClosingDate { get; set; }

}