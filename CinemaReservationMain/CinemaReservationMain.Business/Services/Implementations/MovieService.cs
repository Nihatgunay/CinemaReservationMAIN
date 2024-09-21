using System.Linq.Expressions;
using AutoMapper;
using CinemaReservationMain.Business.Dtos.MovieDtos;
using CinemaReservationMain.Business.Dtos.TheaterDtos;
using CinemaReservationMain.Business.Services.Interfaces;
using CinemaReservationMain.Core.Models;
using CinemaReservationMain.Core.Repositories;
using CinemaReservationMain.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservationMain.Business.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<MovieGetDto> CreateAsync(MovieCreateDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            movie.CreatedDate = DateTime.Now;
            movie.UpdatedDate = DateTime.Now;

            await _movieRepository.CreateAsync(movie);
            await _movieRepository.CommitAsync();

            return _mapper.Map<MovieGetDto>(movie);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new Exception();

            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) throw new Exception("movie not found.");

            _movieRepository.Delete(movie);
            await _movieRepository.CommitAsync();
        }

        public async Task<ICollection<MovieGetDto>> GetByExpression(bool asnotracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes)
        {
            var movies = await _movieRepository.GetByExpression(asnotracking, expression, includes).ToListAsync();

            return _mapper.Map<ICollection<MovieGetDto>>(movies);
        }

        public async Task<MovieGetDto> GetById(int id)
        {
            if (id < 1) throw new Exception();

            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) throw new Exception("movie not found");

            return _mapper.Map<MovieGetDto>(movie);
        }

        public async Task<MovieGetDto> GetSingleByExpression(bool asnotracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes)
        {
            var movie = await _movieRepository.GetByExpression(asnotracking, expression, includes).FirstOrDefaultAsync();
            if (movie == null) throw new Exception("movie not found");

            return _mapper.Map<MovieGetDto>(movie);
        }

        public async Task UpdateAsync(int? id, MovieUpdateDto dto)
        {
            if (id < 1 || id is null) throw new NullReferenceException("id is invalid");

            var movie = await _movieRepository.GetByIdAsync((int)id);
            if (movie == null) throw new Exception("movie not found");

            _mapper.Map(dto, movie);

            movie.UpdatedDate = DateTime.Now;

            await _movieRepository.CommitAsync();
        }
    }
}
