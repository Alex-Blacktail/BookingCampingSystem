using System.Net;
using Booking.System.Application.Identity;
using Booking.System.Application.Identity.DTO;
using Booking.System.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthController : ApiController
    {
        private readonly IUserAuthenticationRepository _repository;

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(IMediator mediator, IUserAuthenticationRepository repository, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
            : base(mediator)
        {
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Регистрация главного администратора
        /// </summary>
        /// <param name="userRegistration"></param>
        /// <returns>Идентификатор зарегистрированного администратора</returns>
        [HttpPost("register/superadmin")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterAdmin(UserRegistrationDto userRegistration)
        {
            var userResult = await _repository.RegisterAdminAsync(userRegistration);

            if (!userResult.Succeeded)
                return new BadRequestObjectResult(userResult);

            var user = await _userManager.FindByEmailAsync(userRegistration.Email);
            return Ok(new { userId = user.Id });
        }

        /// <summary>
        /// Регистрация локального администратора
        /// </summary>
        /// <param name="userRegistration"></param>
        /// <returns>Идентификатор зарегистрированного локального администратора</returns>
        [HttpPost("register/localadmin")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterLocalAdmin(LocalAdminRegistrationDto localAdminRegistrationDto)
        {
            var userResult = await _repository.RegisterLocalAdminAsync(localAdminRegistrationDto);

            if (!userResult.Succeeded)
                return new BadRequestObjectResult(userResult);

            var user = await _userManager.FindByEmailAsync(localAdminRegistrationDto.Email);
            return Ok(new { userId = user.Id });
        }

        /// <summary>
        /// Регистрация родительской учетной записи
        /// </summary>
        /// <param name="parentRegistrationDto"></param>
        /// <returns>Идентификатор пользователя</returns>
        [HttpPost("register/parent")]
        public async Task<IActionResult> RegisterParent(ParentRegistrationDto parentRegistrationDto)
        {
            var userResult = await _repository.RegisterParentAsync(parentRegistrationDto);

            if (!userResult.Succeeded)
                return new BadRequestObjectResult(userResult);

            var user = await _userManager.FindByEmailAsync(parentRegistrationDto.UserRegistration.Email);
            return Ok(new { userId = user.Id });
        }

        /// <summary>
        /// Аутентификация и авторизация в системе
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Токен авторизации, роль, идентификатор пользователя</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto user)
        {
            var isValid = await _repository.ValidateUserAsync(user);
            if (!isValid)
                return Unauthorized();

            var userData = await _userManager.FindByNameAsync(user.UserName);
            var userRoles = await _userManager.GetRolesAsync(userData);
            return Ok(
                new
                {
                    token = await _repository.CreateTokenAsync(),
                    userId = userData.Id,
                    role = userRoles.FirstOrDefault()
                }) ;
        }
    }
}