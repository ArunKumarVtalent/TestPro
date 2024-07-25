using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIPro.CustomDataAnnotations;
using WebAPIPro.DataAccess.IRepository;

namespace WebAPIPro.Models
{
    [Table("Employee")]
    public class Employee
    {
        //public IEmpRepository IEmpRef;
        //public Employee(IEmpRepository _IEmpRef)
        //{
        //    IEmpRef = _IEmpRef;
        //}

        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Please enter name...!")]
        [StringLength(15, ErrorMessage = "Please enter up to 1t chars only...!")]
        //[RegularExpression(@"^{[A-Za-z]+}$", ErrorMessage = "Name should be chars only...!")]
        public string EName { get; set; }

        [Required(ErrorMessage = "Please enter password...!")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Please enter confirm password...!")]
        //[Compare("Password",ErrorMessage = "Password mismatch happend...!")]
        //public string CnfPassword { get; set; }

        [Required(ErrorMessage = "Please select gender...!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter phone...!")]
        //[RegularExpression(@"/^\d{10}$/", ErrorMessage = "Phone number should be digits and 10 numbers only...!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter email address...!")]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage ="Please enter proper email address formate...!")]
        //[ExistingEmailCheck(ErrorMessage = "This email address is already exists. Please provide new email address...!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter salary...!")]
        //[RegularExpression(@"/^\d$/", ErrorMessage = "salary should be digits only...!")]
        //[Range(5000,50000, ErrorMessage = "Please enter salary in between [Including] 5000 to  [Including] 50000...!")]
        [ZeroOrNegetiveCheck(ErrorMessage = "Salary should not accept Zero and Negitive values...!")]
        [SalaryCheck( ErrorMessage = "Salary should in between 5000 and 50000. And It should be divisible by 10...!")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Please enter address...!")]
        public string Address { get; set; }

        [ForeignKey("Department")]
        [Required(ErrorMessage = "Please select deapartment...!")]
        [ZeroOrNegetiveCheck(ErrorMessage = "Please select department...!")]
        public int DeptNo { get; set; }

        public Department Department { get; set; }
    }
}
