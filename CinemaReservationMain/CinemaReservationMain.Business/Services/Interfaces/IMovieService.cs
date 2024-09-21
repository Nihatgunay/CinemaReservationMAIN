using CinemaReservationMain.Business.Dtos.MovieDtos;
using CinemaReservationMain.Core.Models;
using System.Linq.Expressions;

namespace CinemaReservationMain.Business.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieGetDto> CreateAsync(MovieCreateDto dto);
        Task UpdateAsync(int? id, MovieUpdateDto dto);
        Task DeleteAsync(int id);
        Task<MovieGetDto> GetById(int id);
        Task<ICollection<MovieGetDto>> GetByExpression(bool asnotracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes);
        Task<MovieGetDto> GetSingleByExpression(bool asnotracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes);
    }
}
