using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Golowinskiy_NewBostil.Entities;
using Golowinskiy_NewBostil.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Golowinskiy_NewBostil.Controllers
{
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<List<string>> GetRoleByName()
        {
            return await _roleManager.Roles.Select(x => x.Name).ToListAsync();
        }

        [HttpGet]
        public async Task<List<IdentityRole>> GetAllRoles() => await _roleManager.Roles.ToListAsync();

  
        [HttpGet]
        public async Task AddRole(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}