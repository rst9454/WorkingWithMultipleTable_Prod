using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkingWithMultipleTable_Prod.Data;
using WorkingWithMultipleTable_Prod.Models;

namespace WorkingWithMultipleTable_Prod.Controllers
{

    public class DepartmentController : Controller
    {
        private readonly ApplicationContext context;

        public DepartmentController(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await context.Departments.ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> AddDepartment(int? id)
        {
            Department department = new Department();
            if(id != null && id != 0)
            {
                department = await context.Departments.FindAsync(id);
            }
            return View(department);
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            else
            {
                if (department.DepartmentId == 0)
                {
                    await context.Departments.AddAsync(department);
                    
                    TempData["success"] = "Department has been created!";
                }
                else
                {
                    context.Departments.Update(department);
                    TempData["success"] = "Department has been updated!";
                }
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                bool status = context.Employees.Any(x => x.DepartmentId == id);
                if (status)
                {
                    TempData["warning"] = "Department is taken by another employee, so can't delete this!";
                }
                else
                {
                    var department = await context.Departments.FindAsync(id);
                    if (department == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        context.Departments.Remove(department);
                        await context.SaveChangesAsync();
                        TempData["success"] = "Department has been successfully deleted!";
                    }

                }
            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }
    }
}
