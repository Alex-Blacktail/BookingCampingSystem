using Booking.System.Application.LocalAdmins.DTO;

namespace Booking.System.Application.LocalAdmins
{
    public interface ILocalAdminRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CampInfoDto">������ ������ </param>
        /// <returns></returns>
        Task<List<CampInfoDto>> LookRequest(string id);

    }
}
