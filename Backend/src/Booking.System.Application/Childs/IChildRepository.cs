using Booking.System.Application.Childs.DTO;

namespace Booking.System.Application.Childs
{
    public interface IChildRepository
    {
        /// <summary>
        /// ��������� ������ ������� 
        /// </summary>
        /// <param name="�hildDto">������ ������ �������</param>
        /// <returns></returns>
        Task<bool> CreateChild(ChildDto �hildDto);
    }
}
