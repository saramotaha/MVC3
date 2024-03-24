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
        private readonly IDeptInterface _deptRepo;
        private readonly IWebHostEnvironment _env;


        //private IDeptInterface _deptRepo;

        public deptController(IDeptInterface DeptR , IWebHostEnvironment env)
        {
            _deptRepo = DeptR;
            _env = env;

            //_deptRepo = DeptR;
        }


        public IActionResult Index()
        {
            var departments = _deptRepo.GetAll();
            return View(departments);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Department department)
        {
           if(ModelState.IsValid)
            {
                var c=_deptRepo.Add(department);
                if(c>0)
                {
                    return RedirectToAction("Index");
                }

            }

           return View(department);
        }




        public IActionResult Details(int? id,string ViewName="Details")
        {

            if (!id.HasValue)
            {
                return BadRequest();
            }

            var Thedept = _deptRepo.GetById(id.Value);
            
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
                _deptRepo.Update(department);
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
            _deptRepo.Delete(department);
            return RedirectToAction("Index");

        }



    }
}



   
