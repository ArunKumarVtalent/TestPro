using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebAPIPro.DatabaseContext;

namespace WebAPIPro.CustomDataAnnotations
{
    public class ExistingEmailCheckAttribute : ValidationAttribute
    {
        public DBContextPro EmpDb;
        public ExistingEmailCheckAttribute(DBContextPro _EmpDb)
        {
            EmpDb = _EmpDb;
        }
        public override bool IsValid(object value)
        {
            bool flag = true;
            string emailVal = value.ToString();

            // Write a logic to check Email is already available or not
            var Emp = EmpDb.Employees.Where(x => x.Email == emailVal).SingleOrDefaultAsync();

            if (Emp != null)
            {
                flag = false;
            }
            return flag;
        }
    }
}
