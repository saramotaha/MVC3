using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVC3.BLL.Interfaces;
using MVC3.DAL.Models;

namespace MVC3.PL.Controllers
{
    public class EmpController : Controller
    { 
            private readonly IEmployeeInterface _EmpRepo;
            private readonly IWebHostEnvironment _env;


        //private IDeptInterface _deptRepo;

        public EmpController(IEmployeeInterface EmpR, IWebHostEnvironment env)
        {
            _EmpRepo = EmpR;
            _env = env;

        }


        public IActionResult Index()
        {
            var Employees = _EmpRepo.GetAll();
            return View(Employees);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var c = _EmpRepo.Add(employee);
                if (c > 0)
                {
                    return RedirectToAction("Index");
                }

            }

            return View(employee);
        }




        public IActionResult Details(int? id, string ViewName = "Details")
        {

            if (!id.HasValue)
            {
                return BadRequest();
            }

            var TheEmp = _EmpRepo.GetById(id.Value);

            if (TheEmp is null)
            {
                return NotFound();
            }


            return View(ViewName, TheEmp);

        }



        [HttpGet]
        public IActionResult Update(int? id)
        {

            //if (!id.HasValue)
            //{
            //    return BadRequest();
            //}

            //var Thedept = _deptRepo.GetById(id.Value);

            //if (Thedept is null)
            //{
            //    return NotFound();
            //}


            //return View(Thedept);


            return Details(id, "Update");

        }




        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Error ");
            }
            if (!ModelState.IsValid)
            {

                return View(employee);
            }

            try
            {
                _EmpRepo.Update(employee);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Error Excuted");
                }

                return View(employee);
            }




        }



        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }



        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _EmpRepo.Delete(employee);
            return RedirectToAction("Index");

        }
    
    }
}
