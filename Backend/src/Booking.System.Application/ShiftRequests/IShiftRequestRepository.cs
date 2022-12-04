using Booking.System.Application.ShiftRequests.DTO;
using Booking.System.Application.ShiftsRequests.DTO;
using static Booking.System.Application.ShiftsRequests.ShiftRequestRepository;

namespace Booking.System.Application.ShiftsRequests
{
    public interface IShiftRequestRepository
    {
        /// <summary>
        /// Просмотр карточек лагерей
        /// </summary>
        /// <param name="CampCardVm">Объект данных для просмотра карточки</param>
        /// <returns></returns>
        Task<GetShiftRequestDto> GetRequestInfo();

        /// <summary>
        /// добавление карточки лагероя (для супер админа)
        /// </summary>
        /// <param name="capmCardDto">Объект данных для добавления карточки лагеря</param>
        /// <returns></returns>
        /// 
        Task<GetShiftRequestDto> CreateRequest(CreateRequestDto createRequestDto);

        /// <summary>
        /// Получить все смены с занятостью
        /// </summary>
        /// <returns></returns>
        Task<AllShiftRequestsDto> GetAllShiftRequests();

        /// <summary>
        /// Получить действущие смены
        /// </summary>
        /// <returns></returns>
        Task<AllShiftRequestsDto> GetShiftsTodayDate();
        /// <summary>
        /// Получить данные по месяцам для супер админа
        /// </summary>
        /// <returns></returns>
        Task<VisualDataVm> GetMonthsShifts();
    }
}
