using Booking.System.Application.LocalAdmins.DTO;

namespace Booking.System.Application.LocalAdmins
{
    public interface IChildRepository
    {
        /// <summary>
        /// Заполнить данные ребенка 
        /// </summary>
        /// <param name="сhildDto">Объект данных ребенка</param>
        /// <returns></returns>
      //  Task<bool> CreateChild(ChildDto сhildDto);

        /// <summary>
        /// Удалить данные ребенка (по снилсу)
        /// </summary>
        /// <param name="removeChildInfoDto">Объект данных для удаления информации о ребенке</param>
        /// <returns></returns>
     //   Task<bool> RemoveChildInfo(RemoveChildInfoDto removeChildInfoDto);

    }
}
