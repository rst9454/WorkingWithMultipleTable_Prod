

using System.ComponentModel.DataAnnotations;

namespace WorkingWithMultipleTable_Prod.Models.ViewModel
{
    public class EmployeeDepartmentSummaryViewModel
    {
        [Key]
        [Display(Name = "Employee Id :")]
        public int EmployeeId { get; set; }
        [Display(Name = "Deparment Id :")]
        [Range(1,1000,ErrorMessage = "Please select department")]
        public int DepartmentId { get; set; }
        [Display(Name = "First Name :")]
        [Required(ErrorMessage ="Please enter first name")]
        public string FirstName { get; set; } = default!;
        [Display(Name = "Middle Name :")]
        [Required(ErrorMessage = "Please enter middle name")]
        public string? MiddleName { get; set; }
        [Display(Name = "Last Name :")]
        [Required(ErrorMessage = "Please enter last name")]
        public string? LastName { get; set; }
        [Display(Name = "Name :")]
        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
        [Required(ErrorMessage = "Please select gener")]
        public string? Gender { get; set; }
        [Display(Name = "Department :")]
        

        public string DepartmentName { get; set; } = default!;
        [Display(Name = "Department Code :")]
        public string DepartmentCode { get; set; } = default!;
    }
}
