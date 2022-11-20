using System.ComponentModel.DataAnnotations;

namespace API.Models;
public class MDJobs
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string JobCode { get; set; }
    public string Description { get; set; }
    public int LocationId { get; set; }
    public int DepartmentId { get; set; }
    public DateTime PostedDate { get; set; }
    public DateTime ClosingDate { get; set; }
}