using System.ComponentModel.DataAnnotations;

namespace MVC3.PL.ViewModels.User
{
	public class SignUpViewModel
	{
        [Required(ErrorMessage ="UserName Is Required")]
        public string UserName { get; set; }
		


		
		[Required(ErrorMessage ="Email Is Required")]
		[EmailAddress(ErrorMessage ="Invaild Email")]
        public string Email { get; set; }




		[Required(ErrorMessage = "First Name Is Required")]
		[Display(Name = "First Name")]
		public string FName { get; set; }




		[Required(ErrorMessage = "Last Name Is Required")]
		[Display(Name = "Last Name")]
		public string LName { get; set; }




		[Required(ErrorMessage = "Password Is Required")]
		[MinLength(5 , ErrorMessage ="Min Length Of Password Is 5")]
		[DataType(DataType.Password)]
		public string Password { get; set; }





		[Required(ErrorMessage = "ConfirmPassword Is Required")]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string ConfirnPassword { get; set; }



        public bool IsAgree { get; set; }


    }
}
