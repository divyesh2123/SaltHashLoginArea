using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication22.MyHelper;

namespace WebApplication22.ViewModal
{
    public class UserViewModal
    {


        [CustomHireDate(ErrorMessage = "Hire Date must be less than or equal to Today's Date")]
        public DateTime HireDate { get; set; }


        [Required(ErrorMessage = "Company Email address Required")]
        [DataType(DataType.EmailAddress)]
        public string CompanyEmailAddress { get; set; }


        [Required(ErrorMessage = "Company Phone number is Required")]
        [DataType(DataType.PhoneNumber)]
        public int CompanyPhoneNumber { get; set; }


        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public Decimal MinimumSalaryPerEmp { get; set; }

        [Required(ErrorMessage = "No.of working Hours Required")]
        [Range(2, 10, ErrorMessage = "Please Provide correct range. It should be minimum 2 and not more than 10 ")]
        public int WorkingHours { get; set; }


        [Required]
        [StringLength(10, MinimumLength = 5)]
        [Display(Name = "User name")]
        [RegularExpression(@"(\S\D)+", ErrorMessage = " Space and numbers not allowed")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Enter Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [Display(Name = "Re-enter Password")]
        [Compare("CurrentPassword", ErrorMessage = "Please Re-enter Password Again")]
        public string ComparedPassword { get; set; }



    }
}