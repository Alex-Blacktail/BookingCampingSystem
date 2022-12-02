using Microsoft.AspNetCore.Identity;
using Booking.System.Application.Identity.DTO;

namespace Booking.System.Application.Identity
{
    public interface IUserAuthenticationRepository
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userRetistrationDto">Объект данных для регистрации</param>
        /// <returns></returns>
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userRetistrationDto);

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
