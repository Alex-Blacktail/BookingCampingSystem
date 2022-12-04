using System.ComponentModel.DataAnnotations;

namespace Booking.System.Application.Identity.DTO
{
    public class LocalAdminRegistrationDto
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; init; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; init; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; init; }

        /// <summary>
        /// Отчество, если есть
        /// </summary>
        public string? ThirdName { get; init; }

        /// <summary>
        /// Почтовый адрес
        /// </summary>
        public string? Email { get; init; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string? PhoneNumber { get; init; }
    }
}
