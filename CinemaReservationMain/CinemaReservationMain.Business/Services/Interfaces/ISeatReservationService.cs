using CinemaReservationMain.Business.Dtos.ReservationDtos;
using CinemaReservationMain.Business.Dtos.SeatReservationDtos;
using CinemaReservationMain.Core.Models;
using System.Linq.Expressions;

namespace CinemaReservationMain.Business.Services.Interfaces
{
    public interface ISeatReservationService
    {
        Task<SeatReservationGetDto> CreateAsync(SeatReservationCreateDto dto);
        Task UpdateAsync(int? id, SeatReservationUpdateDto dto);
        Task DeleteAsync(int id);
        Task<SeatReservationGetDto> GetById(int id);
        Task<ICollection<SeatReservationGetDto>> GetByExpression(bool asnotracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes);
        Task<SeatReservationGetDto> GetSingleByExpression(bool asnotracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes);
    }
}
