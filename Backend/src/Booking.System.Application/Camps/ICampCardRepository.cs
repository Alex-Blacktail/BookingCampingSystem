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

    }
}
