using Microsoft.AspNetCore.Mvc;
using MVC3.BLL.Interfaces;
using MVC3.BLL.Repos;
using MVC3.DAL.Models;

namespace MVC3.PL.Controllers
{
    public class deptController : Controller
    {
        private readonly IDeptInterface _deptRepo;


        //private IDeptInterface _deptRepo;

        public deptController(IDeptInterface DeptR)
        {
            _deptRepo = DeptR;

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


    }
}
