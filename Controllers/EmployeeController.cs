using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkingWithMultipleTable_Prod.Data;
using WorkingWithMultipleTable_Prod.Models.ViewModel;

namespace WorkingWithMultipleTable_Prod.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            //Using Merge model
            //EmployeeDepartmentListViewModel emp = new EmployeeDepartmentListViewModel();
            //emp.employees = context.Employees.ToList();
            //emp.departments = context.Departments.ToList();
            //emp.employees = empData;
            //emp.departments = depData;


            //EmployeeDepartmentListViewModel emp = new EmployeeDepartmentListViewModel();
            //var empData = context.Employees.FromSqlRaw("Select * from Employees").ToList();
            //var depData = context.Departments.FromSqlRaw("Select * from Departments").ToList();
            //emp.employees = empData;
            //emp.departments = depData;



            //Using Join Model
            //var data = (from e in context.Employees
            //            join d in context.Departments
            //            on e.DepartmentId equals d.DepartmentId
            //            select new EmployeeDepartmentSummaryViewModel
            //            {
            //                EmployeeId=e.EmployeeId,
            //                FirstName=e.FirstName,
            //                MiddleName=e.MiddleName,
            //                LastName=e.LastName,
            //                Gender=e.Gender,
            //                DepartmentCode=d.DepartmentCode,
            //                DepartmentName=d.DepartmentName
            //            }).ToList();


            //var data = context.employeeDepartmentSummaryViewModels.FromSqlRaw("select e.EmployeeId,e.FirstName,e.MiddleName,e.LastName,e.Gender,d.DepartmentId,d.DepartmentCode,d.DepartmentName from Employees e join Departments d on e.DepartmentId =d.DepartmentId");


            //Using Procedure get the Data

            //var empData = context.Employees.FromSqlRaw("exec GetEmploee");
            //var depData = context.Departments.FromSqlRaw("exec GetDepartments");


            var result = context.employeeDepartmentSummaryViewModels.FromSqlRaw("exec GetEmployeeDepartmentsList").ToList();


            return View(result);
        }
    }
}
