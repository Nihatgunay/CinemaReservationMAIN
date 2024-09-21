using CinemaReservationMain.Business.Dtos.ShowTimeDtos;
using CinemaReservationMain.Core.Models;
using System.Linq.Expressions;

namespace CinemaReservationMain.Business.Services.Interfaces
{
    public interface IShowTimeService
    {
        Task<ShowTimeGetDto> CreateAsync(ShowTimeCreateDto dto);
        Task UpdateAsync(int? id, ShowTimeUpdateDto dto);
        Task DeleteAsync(int id);
        Task<ShowTimeGetDto> GetById(int id);
        Task<ICollection<ShowTimeGetDto>> GetByExpression(bool asnotracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes);
        Task<ShowTimeGetDto> GetSingleByExpression(bool asnotracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes);
    }
}
