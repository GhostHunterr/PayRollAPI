using Microsoft.EntityFrameworkCore;
using PayrollCoreAPI.Models;


namespace PayRollApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        public DbSet<Employees> tblEmployee { get; set; }


    }
}
