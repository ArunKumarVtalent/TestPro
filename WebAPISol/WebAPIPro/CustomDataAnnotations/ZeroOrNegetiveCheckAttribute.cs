using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPIPro.CustomDataAnnotations
{
    public class ZeroOrNegetiveCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool flag = true;
            int Val = Convert.ToInt32(value);

            if (Val <= 0)
            {
                flag = false;
            }

            return flag;
        }

        //public override bool IsValid(object value)
        //{
        //    int Val = Convert.ToInt32(value);

        //    if (Val <= 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
    }
}
