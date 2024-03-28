using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVC3.BLL.Interfaces;
using MVC3.DAL.Models;
using MVC3.PL.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MVC3.PL.Controllers
{
    public class EmpController : Controller
    { 
        private readonly IEmployeeInterface _EmpRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        //private IDeptInterface _deptRepo;

        public EmpController(IEmployeeInterface EmpR,IMapper mapper, IWebHostEnvironment env)
        {
            _EmpRepo = EmpR;
            _mapper = mapper;
            _env = env;
        }


        public IActionResult Index(string SearchIn)
        {
            var Employees = Enumerable.Empty<Employee>();
            if (string.IsNullOrEmpty(SearchIn))
            {
                 Employees = _EmpRepo.GetAll();
                
            }
            else
            {
                 Employees = _EmpRepo.SeachByName(SearchIn.ToLower());
            }
            var mappedEmp = _mapper.Map<IEnumerable<Employee>,IEnumerable<EmpViewModel>>(Employees);
            return View(Employees);

        }



        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["Departments"]=_departmentRepo.GetAll();
            return View();
        }



        [HttpPost]
        public IActionResult Create(EmpViewModel EmployeeVM)
        {
            if (ModelState.IsValid)
            {
                //var Mapped=new Employee()
                //{

                //}

                var mappedEmp = _mapper.Map<EmpViewModel, Employee>(EmployeeVM);
                var c = _EmpRepo.Add(mappedEmp);
                if (c > 0)
                {
                    return RedirectToAction("Index");
                }

            }

            return View(EmployeeVM);
        }




        public IActionResult Details(int? id, string ViewName = "Details")
        {

            if (!id.HasValue)
            {
                return BadRequest();
            }
           

            var TheEmp = _EmpRepo.GetById(id.Value);
            var mappedEmp = _mapper.Map<Employee, EmpViewModel>(TheEmp);

            if (TheEmp is null)
            {
                return NotFound();
            }


            return View(ViewName, mappedEmp);

        }



        [HttpGet]
        public IActionResult Update(int? id)
        {
            //ViewData["Departments"] = _departmentRepo.GetAll();

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
        public IActionResult Update([FromRoute] int id, EmpViewModel EmployeeVM)
        {
            if (id !=EmployeeVM.Id)
            {
                return BadRequest("Error ");
            }
            if (!ModelState.IsValid)
            {

                return View(EmployeeVM);
            }

            try
            {
                var mappedEmp = _mapper.Map<EmpViewModel, Employee>(EmployeeVM);
                _EmpRepo.Update(mappedEmp);
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

                return View(EmployeeVM);
            }




        }



        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }



        [HttpPost]
        public IActionResult Delete(EmpViewModel EmployeeVM)
        {
            var mappedEmp = _mapper.Map<EmpViewModel, Employee>(EmployeeVM);
            _EmpRepo.Delete(mappedEmp);
            return RedirectToAction("Index");

        }
    
    }
}
