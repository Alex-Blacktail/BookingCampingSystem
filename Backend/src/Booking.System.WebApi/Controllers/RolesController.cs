using Booking.System.Application.Identity.Models;
using Booking.System.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Booking.System.WebApi.Controllers
{
    public class RolesController : ApiController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RolesController(IMediator mediator, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) 
            : base(mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddRole")]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                    return Ok();

                return BadRequest(result);
            }
            return BadRequest();

        }

        [Authorize(Roles = "admin")]
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                    return Ok();

                return BadRequest(result);
            }

            return BadRequest();
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> Edit(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();

                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return Ok(model);
            }

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost("EditUserRole")]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                var totalRoles = await _userManager.GetRolesAsync(user);

                return Ok(totalRoles);
            }

            return NotFound();
        }

        [HttpGet("Initialize")]
        public async Task<IActionResult> InitializeRoles()
        {
            await InitializeRolesAsync(_userManager, _roleManager);
            return Ok("Roles are added");
        }

        private static async Task InitializeRolesAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@test.com";
            string password = "Admin123";

            if (await roleManager.FindByNameAsync(adminEmail) == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await roleManager.FindByNameAsync(adminEmail) == null)
            {
                await roleManager.CreateAsync(new IdentityRole("localadmin"));
            }

            if (await roleManager.FindByNameAsync(adminEmail) == null)
            {
                await roleManager.CreateAsync(new IdentityRole("parent"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new AppUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
