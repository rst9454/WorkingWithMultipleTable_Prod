using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
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
        private static string EveryFirstCharacterCapital(string input)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(input))
            {

                var data = input.Split(' ');
                //for(int i=0;i<data.Length; i++)
                //{
                //    sb.Append(data[i].First().ToString().ToUpper() + data[i].Substring(1) + " ");
                //}

                foreach (var d in data)
                {
                    sb.Append(d.First().ToString().ToUpper() + d.Substring(1) + " ");
                }
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
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






            //var data = context.employeeDepartmentSummaryViewModels.FromSqlRaw("select e.EmployeeId,e.FirstName,e.MiddleName,e.LastName,e.Gender,d.DepartmentId,d.DepartmentCode,d.DepartmentName from Employees e join Departments d on e.DepartmentId =d.DepartmentId");


            //Using Procedure get the Data

            //var empData = context.Employees.FromSqlRaw("exec GetEmploee");
            //var depData = context.Departments.FromSqlRaw("exec GetDepartments");


            //var result = context.employeeDepartmentSummaryViewModels.FromSqlRaw("exec GetEmployeeDepartmentsList").ToList();


            //Using Join Model
            var data = (from e in context.Employees
                        join d in context.Departments
                        on e.DepartmentId equals d.DepartmentId
                        select new EmployeeDepartmentSummaryViewModel
                        {
                            EmployeeId = e.EmployeeId,
                            FirstName = EveryFirstCharacterCapital(e.FirstName),
                            MiddleName = EveryFirstCharacterCapital(e.MiddleName),
                            LastName = EveryFirstCharacterCapital(e.LastName),
                            Gender = EveryFirstCharacterCapital(e.Gender),
                            DepartmentCode = d.DepartmentCode.ToUpper(),
                            DepartmentName = EveryFirstCharacterCapital(d.DepartmentName)
                        }).ToList();

            return View(data);
        }
    }
}
