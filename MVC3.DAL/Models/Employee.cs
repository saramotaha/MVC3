using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.DAL.Models
{
   public enum Gender
    {
        [EnumMember(Value ="Male")]
        Male=1,

        [EnumMember(Value = "Female")]
        Female =2
    }

    public enum EmployeeType
    {
        [EnumMember(Value ="FullTime")]
        FullTime=1,


        [EnumMember(Value ="PartTime")]
        PartTime=2
    }


    public class Employee:ModelBase
    {
      

        [Required]
        [MaxLength(50,ErrorMessage ="Max Lenght is 50")]
        [MinLength(10, ErrorMessage = "Min Lenght is 10")]
        public string Name { get; set; }





        [Range(20 , 35)]
        public int Age { get; set; }




        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{4,10}-[a-zA-Z]{4,15}-[a-zA-Z]{5,15}$" , ErrorMessage ="Address Must be like 123-Street-city-country")]
        public string Address { get; set; }




        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }




        [Display(Name ="Is Ative")]
        public bool IsActive { get; set; }


        [EmailAddress]
        public string Email { get; set; }




        [Phone]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        
        
        
  
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }



        public Gender Gender { get; set; }


        public EmployeeType EmpType { get; set; }





        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }=DateTime.Now;




        public bool IsDeleted { get; set; } = false;

        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
