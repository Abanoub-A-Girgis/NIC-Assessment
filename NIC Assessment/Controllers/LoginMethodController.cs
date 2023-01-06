using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NIC_Assessment.DB;
using NIC_Assessment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NIC_Assessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginMethodController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        public InformationDBContext _context { get; set; }
        public LoginMethodController(InformationDBContext context, SignInManager<AppUser> signInManager)
        {
            this._context = context;
            this._signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn([FromForm] LogInModel model)
        {
            if(ModelState.IsValid && model.UserName != null && model.Password != null)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return Redirect("~/Home");
                }
            }
            return Redirect("~/Login");
        }
    }
}

