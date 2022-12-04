using Booking.System.Application;
using Booking.System.Application.Identity;
using Booking.System.Application.Identity.DTO;
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
        private readonly IUserAuthenticationRepository _repository;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RolesController(IMediator mediator, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, CampDbContext context, IUserAuthenticationRepository repository) 
            : base(mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _repository = repository;

            context.AspNetRoles.ToList();
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

        private async Task InitializeRolesAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@test.com";
            string adminPassword = "Admin123";

            string localEmail = "local@test.com";
            string localPassword = "Local123";

            string parentEmail = "parent@test.com";
            string parentPassword = "Parent123";

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
                await _repository.RegisterUserAsync(new UserRegistrationDto
                {
                    Email = adminEmail,
                    FirstName = "admin",
                    LastName = "admin",
                    ThirdName = "admin",
                    Password = adminPassword,
                    UserName = adminEmail,
                });
            }

            if (await userManager.FindByNameAsync(localEmail) == null)
            {
                //TODO прокинуть регистрацию норм сюда
                var local= new AppUser { Email = localEmail, UserName = localEmail };
                IdentityResult result = await userManager.CreateAsync(local, localPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(local, "localadmin");
                }
            }

            if (await userManager.FindByNameAsync(parentEmail) == null)
            {
                await _repository.RegisterParentAsync(new ParentRegistrationDto
                {
                    UserRegistration = new UserRegistrationDto
                    {
                        Email = parentEmail,
                        FirstName = "parent",
                        LastName = "parent",
                        ThirdName = "parent",
                        Password = parentPassword,
                        UserName = parentEmail,
                    },
                    Address = "Оренбургская область, г. Оренбург, ул. Советская 1",
                    Birthday = DateTime.Now.AddYears(-30).ToString("dd-MM-yy"),
                    Country = "Российская Федерация",
                    StatusId = 1,
                    SNILS = "1234567890",
                    PassportType = "ru",
                    PassportNumber = "666666",
                    PassportSerial = "4444",
                    PassportDateOfIssue = DateTime.Now.AddYears(-10).ToString("dd-MM-yy"),
                    PassportIssuedBy = "pass",
                    PassportValidity = "pass"
                }); 
            }
        }
    }
}
