using CinemaReservationMain.Business.Dtos.ReservationDtos;
using CinemaReservationMain.Core.Models;
using System.Linq.Expressions;

namespace CinemaReservationMain.Business.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationGetDto> CreateAsync(ReservationCreateDto dto);
        Task UpdateAsync(int? id, ReservationUpdateDto dto);
        Task DeleteAsync(int id);
        Task<ReservationGetDto> GetById(int id);
        Task<ICollection<ReservationGetDto>> GetByExpression(bool asnotracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes);
        Task<ReservationGetDto> GetSingleByExpression(bool asnotracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes);
    }
}
