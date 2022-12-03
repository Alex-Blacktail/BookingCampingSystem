using Booking.System.Application.Childs.DTO;

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
    }
}
