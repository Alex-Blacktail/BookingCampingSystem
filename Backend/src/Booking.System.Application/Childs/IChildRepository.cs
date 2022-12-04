using Booking.System.Application.Childs.DTO;
using Microsoft.AspNetCore.Identity;
using System.Data;

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

        /// <summary>
        /// ������� ������ ������� (�� ������)
        /// </summary>
        /// <param name="removeChildInfoDto">������ ������ ��� �������� ���������� � �������</param>
        /// <returns></returns>
        Task<bool> RemoveChildInfo(RemoveChildInfoDto removeChildInfoDto);
        
    }
}
