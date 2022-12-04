using Booking.System.Application.Childs.DTO;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Booking.System.Application.Childs
{
    public interface IChildRepository
    {
        /// <summary>
        /// Заполнить данные ребенка 
        /// </summary>
        /// <param name="сhildDto">Объект данных ребенка</param>
        /// <returns></returns>
        Task<bool> CreateChild(ChildDto сhildDto);

        /// <summary>
        /// Удалить данные ребенка (по снилсу)
        /// </summary>
        /// <param name="removeChildInfoDto">Объект данных для удаления информации о ребенке</param>
        /// <returns></returns>
        Task<bool> RemoveChildInfo(RemoveChildInfoDto removeChildInfoDto);
        
    }
}
