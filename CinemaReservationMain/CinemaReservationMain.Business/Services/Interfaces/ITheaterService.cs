using CinemaReservationMain.Business.Dtos.TheaterDtos;
using CinemaReservationMain.Core.Models;
using System.Linq.Expressions;

namespace CinemaReservationMain.Business.Services.Interfaces
{
    public interface ITheaterService
	{
        Task<TheaterGetDto> CreateAsync(TheaterCreateDto dto);
        Task UpdateAsync(int? id, TheaterUpdateDto dto);
        Task DeleteAsync(int id);
        Task<TheaterGetDto> GetById(int id);
        Task<ICollection<TheaterGetDto>> GetByExpression(bool asnotracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes);
        Task<TheaterGetDto> GetSingleByExpression(bool asnotracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes);
    }
}
