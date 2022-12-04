using Booking.System.Application.ShiftsRequests.DTO;

namespace Booking.System.Application.ShiftsRequests
{
    public interface IShiftRequestRepository
    {
        /// <summary>
        /// �������� �������� �������
        /// </summary>
        /// <param name="CampCardVm">������ ������ ��� ��������� ��������</param>
        /// <returns></returns>
        Task<ShiftRequestDto> GetRequestInfo();

        /// <summary>
        /// ���������� �������� ������� (��� ����� ������)
        /// </summary>
        /// <param name="capmCardDto">������ ������ ��� ���������� �������� ������</param>
        /// <returns></returns>
    }
}
