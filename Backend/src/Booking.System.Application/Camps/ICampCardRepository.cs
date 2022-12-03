using Microsoft.AspNetCore.Identity;
using Booking.System.Application.Identity.DTO;
using Booking.System.Application.Camps.DTO;

namespace Booking.System.Application.Camps
{
    public interface ICampCardRepository
    {
        /// <summary>
        /// Просмотр карточек лагерей
        /// </summary>
        /// <param name="CampCardVm">Объект данных для просмотра карточки</param>
        /// <returns></returns>
        Task<CampCardVm> GetCampCards();

        /// <summary>
        /// добавление карточки лагероя (для супер админа)
        /// </summary>
        /// <param name="capmCardDto">Объект данных для добавления карточки лагеря</param>
        /// <returns></returns>
        Task<bool> CreateCampCard(CapmCardDto capmCardDto);
    }
}
