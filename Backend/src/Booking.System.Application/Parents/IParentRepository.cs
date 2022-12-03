using Booking.System.Application.Parents.DTO;

namespace Booking.System.Application.Parents
{
    public interface IParentRepository
    {
        /// <summary>
        /// �������� ���������� � �������� � ��� �������/�����
        /// </summary>
        /// <returns></returns>
        Task<ParentDto> GetCampCards(string parentId);

       
    }
}
