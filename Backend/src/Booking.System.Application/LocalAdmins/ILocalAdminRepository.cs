using Booking.System.Application.LocalAdmins.DTO;

namespace Booking.System.Application.LocalAdmins
{
    public interface IChildRepository
    {
        /// <summary>
        /// ��������� ������ ������� 
        /// </summary>
        /// <param name="�hildDto">������ ������ �������</param>
        /// <returns></returns>
      //  Task<bool> CreateChild(ChildDto �hildDto);

        /// <summary>
        /// ������� ������ ������� (�� ������)
        /// </summary>
        /// <param name="removeChildInfoDto">������ ������ ��� �������� ���������� � �������</param>
        /// <returns></returns>
     //   Task<bool> RemoveChildInfo(RemoveChildInfoDto removeChildInfoDto);

    }
}
