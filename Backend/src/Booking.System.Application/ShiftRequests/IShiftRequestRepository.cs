using Booking.System.Application.ShiftsRequests.DTO;

namespace Booking.System.Application.ShiftsRequests
{
    public interface IShiftRequestRepository
    {
        /// <summary>
        /// Просмотр карточек лагерей
        /// </summary>
        /// <param name="CampCardVm">Объект данных для просмотра карточки</param>
        /// <returns></returns>
        Task<ShiftRequestDto> GetRequestInfo();

        /// <summary>
        /// добавление карточки лагероя (для супер админа)
        /// </summary>
        /// <param name="capmCardDto">Объект данных для добавления карточки лагеря</param>
        /// <returns></returns>
    }
}
