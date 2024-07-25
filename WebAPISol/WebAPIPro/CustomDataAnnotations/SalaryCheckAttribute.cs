using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPIPro.CustomDataAnnotations
{
    public class SalaryCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool flag = true;
            int ValSal = Convert.ToInt32(value);

            if ((ValSal < 5000) || (ValSal > 50000))
            {
                flag = false;
            }
            else
            {
                if (ValSal % 10 != 0)
                {
                    flag = false;
                }               
            }

            return flag;
        }
    }
}
