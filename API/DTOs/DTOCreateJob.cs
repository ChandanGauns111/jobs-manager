using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class DTOJobRequest
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    [StringLength(200)]
    public string Description { get; set; }
    [Required]
    [Range(1,2147483647)]
    public int LocationId { get; set; }
    [Required]
    [Range(1,2147483647)]
    public int DepartmentId { get; set; }
    [Required]
    public DateTime ClosingDate { get; set; }
}

public class DTOJobResponse
{
    public int JobId { get; set; }
}