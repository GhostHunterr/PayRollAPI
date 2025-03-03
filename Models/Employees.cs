using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollCoreAPI.Models
{
    [Table("tblEmployee", Schema = "dbo")]
    public class Employees
    {
        [Key]
        public int emp_id { get; set; }
        public string? emp_name { get; set; }
        public string? emp_email { get; set; }
        public string? emp_password { get; set; }
        public string? emp_gender { get; set; }
        public Nullable<int> noOfDependants { get; set; }
        public Nullable<decimal> additions { get; set; }
        public Nullable<decimal> itex { get; set; }
        public Nullable<decimal> cpp { get; set; }
        public Nullable<decimal> ei { get; set; }
        public Nullable<decimal> grosssalary { get; set; }

    }
}
