using Microsoft.AspNetCore.Identity;
using Booking.System.Application.Identity.DTO;

namespace Booking.System.Application.Identity
{
    public interface IUserAuthenticationRepository
    {
        /// <summary>
        /// Регистрация супер админа
        /// </summary>
        /// <param name="userRetistrationDto">Объект данных для регистрации супер админа</param>
        /// <returns></returns>
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userRetistrationDto);

        /// <summary>
        /// Регистрация родителя
        /// </summary>
        /// <param name="parentRegistrationDto">Объект данных для регистрации родителя </param>
        /// <returns></returns>
        Task<IdentityResult> RegisterParentAsync(ParentRegistrationDto parentRegistrationDto);

        /// <summary>
        /// Проверка валидности данных для входа
        /// </summary>
        /// <param name="loginDto">Объект данных входа</param>
        /// <returns></returns>
        Task<bool> ValidateUserAsync(UserLoginDto loginDto);

        /// <summary>
        /// Генерация JWT-токена
        /// </summary>
        /// <returns>Токен авторизации</returns>
        Task<string> CreateTokenAsync();
    }
}
