using MVC3.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace MVC3.PL.ViewModels
{
    public class EmpViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Max Lenght is 50")]
        [MinLength(10, ErrorMessage = "Min Lenght is 10")]
        public string Name { get; set; }





        [Range(20, 35)]
        public int Age { get; set; }




        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{4,10}-[a-zA-Z]{4,15}-[a-zA-Z]{5,15}$", ErrorMessage = "Address Must be like 123-Street-city-country")]
        public string Address { get; set; }




        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }




        [Display(Name = "Is Ative")]
        public bool IsActive { get; set; }


        [EmailAddress]
        public string Email { get; set; }




        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }




        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }



        public Gender Gender { get; set; }


        public EmployeeType EmpType { get; set; }


        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public IFormFile Image { get; set; }

        public string imageName { get; set; }
    }
}


