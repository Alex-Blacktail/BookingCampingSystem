using Microsoft.AspNetCore.Identity;
using Booking.System.Application.Identity.DTO;
using Booking.System.Application.Camps.DTO;

namespace Booking.System.Application.Camps
{
    public interface ICampCardRepository
    {
        /// <summary>
        /// �������� �������� �������
        /// </summary>
        /// <param name="CampCardVm">������ ������ ��� ��������� ��������</param>
        /// <returns></returns>
        Task<CampCardVm> GetCampCards();

    }
}
