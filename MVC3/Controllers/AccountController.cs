using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC3.DAL.Models;
using MVC3.PL.ViewModels.User;
using System.Threading.Tasks;

namespace MVC3.PL.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
		}
        #region SignUp

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        } 
        
        
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {

            if(ModelState.IsValid)
            {
                var user=await _userManager.FindByNameAsync(model.UserName);
                
                if(user is null)
                {

					user = new ApplicationUser
					{
						FName = model.FName,
						LName = model.LName,
						UserName = model.UserName,
						Email = model.Email,
						IsAgree = model.IsAgree


					};


                   var result=await _userManager.CreateAsync(user,model.Password);

                    if(result.Succeeded)
                    {
                        return RedirectToAction("SignIn");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                }

                ModelState.AddModelError(string.Empty, "This UserName Is Used For Another Account");

               
            }
            return View();
        } 

        #endregion



        public new ActionResult SignIn()
        {
            return View();

        }
    }


}
