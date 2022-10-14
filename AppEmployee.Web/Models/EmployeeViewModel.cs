using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppEmployee.Web.Models
{
    public class EmployeeViewModel
    {
        public int Emp_ID { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string Emp_LastName { get; set; }
        [Display(Name = "FirstName")]
        [Required]
        public string Emp_FirstName { get; set; }
        [Required]
        [Display(Name = "Phone")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Invalid format, example: (XXX) XXX-XXXX")]
        public string Emp_Phone { get; set; }
        [Required]
        [Display(Name = "Zip")]
        public string Emp_Zip { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "HireDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Emp_HireDate { get; set; }
    }
}
