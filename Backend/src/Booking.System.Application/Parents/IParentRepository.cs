using Booking.System.Application.Parents.DTO;

namespace Booking.System.Application.Parents
{
    public interface IParentRepository
    {
        /// <summary>
        /// Просмотр информации о родителе и его ребенке/детях
        /// </summary>
        /// <returns></returns>
        Task<ParentDto> GetCampCards(string parentId);

       
    }
}
