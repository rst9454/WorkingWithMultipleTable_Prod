

using System.ComponentModel.DataAnnotations;

namespace WorkingWithMultipleTable_Prod.Models.ViewModel
{
    public class EmployeeDepartmentSummaryViewModel
    {
        [Key]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; } = default!;
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
        public string? Gender { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; } = default!;
        [Display(Name = "Department Code")]
        public string DepartmentCode { get; set; } = default!;
    }
}
