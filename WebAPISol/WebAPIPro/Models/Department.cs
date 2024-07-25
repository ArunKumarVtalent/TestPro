using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIPro.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DeptNo { get; set; }
        public string Dname { get; set; }
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
