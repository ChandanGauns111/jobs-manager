namespace API.DTOs;

public class DTOJobDetailsResponse
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Location Location { get; set; }
    public Department Department { get; set; }
    public DateTime PostedDate { get; set; }
    public DateTime ClosingDate { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class Location
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int Zip { get; set; }
}