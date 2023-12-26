using CodeCloude.Models;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodeCloude.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController( RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;

        }
        public IActionResult ShowRoles()
        {
           var roles =_roleManager.Roles;
            return View(roles);
        }
        [Authorize]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRole model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Name = model.RoleName,
                };
               
                        var result =await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ShowRoles");
                }


            }
            return View();
        }
    }
}
