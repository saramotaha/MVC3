using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVC3.BLL.Interfaces;
using MVC3.BLL.Repos;
using MVC3.DAL.Models;
using MVC3.PL.Helpers;
using MVC3.PL.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MVC3.PL.Controllers
{
    public class EmpController : Controller
    { 
        //private readonly IEmployeeInterface _EmpRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        //private IDeptInterface _deptRepo;

        public EmpController(
            IUnitOfWork unitOfWork,IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            ////_EmpRepo = EmpR;
            _mapper = mapper;
            _env = env;
        }


        public IActionResult Index(string SearchIn)
        {
            var Employees = Enumerable.Empty<Employee>();
            var EmpRepositry = _unitOfWork.Repo<Employee>() as EmployeeRepo;

            if (string.IsNullOrEmpty(SearchIn))
            {
                 Employees = _unitOfWork.Repo<Employee>().GetAll();
                
            }
            else
            {
                 Employees = EmpRepositry.SeachByName(SearchIn.ToLower());
            }
            var mappedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmpViewModel>>(Employees);
            return View(mappedEmp);

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

                //var fileName=documentSetting.UploadFile(EmployeeVM.Image, "Images");

                EmployeeVM.imageName = documentSetting.UploadFile(EmployeeVM.Image, "Images");
                //var Mapped=new Employee()
                //{

                //}

                var mappedEmp = _mapper.Map<EmpViewModel, Employee>(EmployeeVM);

                //mappedEmp.imageName = fileName;


                _unitOfWork.Repo<Employee>().Add(mappedEmp);
                var c = _unitOfWork.complete();
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
           

            var TheEmp = _unitOfWork.Repo<Employee>().GetById(id.Value);
            var mappedEmp = _mapper.Map<Employee, EmpViewModel>(TheEmp);

            if (TheEmp is null)
            {
                return NotFound();
            }

            if (ViewName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                TempData["imageName"] = TheEmp.imageName;
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
                _unitOfWork.Repo<Employee>().Update(mappedEmp);
                _unitOfWork.complete();
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
            EmployeeVM.imageName = TempData["imageName"] as string;
            var mappedEmp = _mapper.Map<EmpViewModel, Employee>(EmployeeVM);
            _unitOfWork.Repo<Employee>().Delete(mappedEmp);
            var count=_unitOfWork.complete();
            if (count > 0)
            {
                documentSetting.DeleteFile(EmployeeVM.imageName, "Images");
                return RedirectToAction("Index");
            }

            return View(EmployeeVM);
            

        }
    
    }
}
