using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
public class DataContext : DbContext
{
    public DbSet<MDJobs> Jobs { get; set; }
    public DbSet<MDDepartment> Department { get; set; }
    public DbSet<MDLocation> Location { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
    {
        optionBuilder.UseSqlServer("Server=.;Database=jobs-manager;User Id=sa;Password=;");
    }
}