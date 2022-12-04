using Booking.System.Application.ShiftRequests.DTO;
using Booking.System.Application.ShiftsRequests.DTO;
using static Booking.System.Application.ShiftsRequests.ShiftRequestRepository;

namespace Booking.System.Application.ShiftsRequests
{
    public interface IShiftRequestRepository
    {
        /// <summary>
        /// �������� �������� �������
        /// </summary>
        /// <param name="CampCardVm">������ ������ ��� ��������� ��������</param>
        /// <returns></returns>
        Task<GetShiftRequestDto> GetRequestInfo();

        /// <summary>
        /// ���������� �������� ������� (��� ����� ������)
        /// </summary>
        /// <param name="capmCardDto">������ ������ ��� ���������� �������� ������</param>
        /// <returns></returns>
        /// 
        Task<GetShiftRequestDto> CreateRequest(CreateRequestDto createRequestDto);

        /// <summary>
        /// �������� ��� ����� � ����������
        /// </summary>
        /// <returns></returns>
        Task<AllShiftRequestsDto> GetAllShiftRequests();

        /// <summary>
        /// �������� ���������� �����
        /// </summary>
        /// <returns></returns>
        Task<AllShiftRequestsDto> GetShiftsTodayDate();
        /// <summary>
        /// �������� ������ �� ������� ��� ����� ������
        /// </summary>
        /// <returns></returns>
        Task<VisualDataVm> GetMonthsShifts();
    }
}
