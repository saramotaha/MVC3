using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using MVC3.BLL.Interfaces;
using MVC3.BLL.Repos;
using MVC3.DAL.Models;
using System;


namespace MVC3.PL.Controllers
{
    public class deptController : Controller
    {
       // private readonly IDeptInterface _deptRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;


        //private IDeptInterface _deptRepo;

        public deptController(/*IDeptInterface DeptR*/ IUnitOfWork unitOfWork , IWebHostEnvironment env)
        {
            //_deptRepo = DeptR;
            _unitOfWork = unitOfWork;
            _env = env;

            //_deptRepo = DeptR;
        }


        public IActionResult Index()
        {

            ViewData["Message"] = "Hello and Welcome Here using ViewData";

            ViewBag.Message= "Hi ,,,, Sara  using ViewBag";

            var departments = _unitOfWork.Repo<Department>().GetAll();
            return View(departments);
        }



        [HttpGet]
        public IActionResult Create()
        {
            TempData.Keep();
            return View();
        }



        [HttpPost]
        public IActionResult Create(Department department)
        {
           if(ModelState.IsValid)
            {
                _unitOfWork.Repo<Department>().Add(department);
                var c = _unitOfWork.complete();
                if(c>0)
                {
                    TempData["Message"] = "Welcome U Have Created A Department";
  
                }
                else
                {
                    TempData["Message"] = "Error !  There Is No Department Created";

                }
                return RedirectToAction("Index");

            }

           return View(department);
        }




        public IActionResult Details(int? id,string ViewName="Details")
        {

            if (!id.HasValue)
            {
                return BadRequest();
            }

            var Thedept = _unitOfWork.Repo<Department>().GetById(id.Value);
            
            if(Thedept is null)
            {
                return NotFound();
            }


            return View(ViewName,Thedept);

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
        public IActionResult Update([FromRoute]int id , Department department)
        {
            if(id!=department.Id)
            {
                return BadRequest("Error ");
            }
            if (!ModelState.IsValid) {
            
                return View(department);
            }

            try
            {
                _unitOfWork.Repo<Department>().Update(department);
                _unitOfWork.complete();

                return RedirectToAction("Index");
            }
            catch (System.Exception  ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Error Excuted");
                }

                return View(department);
            }




        }



        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }



        [HttpPost]
        public IActionResult Delete(Department department)
        {
            _unitOfWork.Repo<Department>().Delete(department);
            _unitOfWork.complete();
            return RedirectToAction("Index");

        }



    }
}



   
