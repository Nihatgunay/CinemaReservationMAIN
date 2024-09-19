using System.Linq.Expressions;
using AutoMapper;
using CinemaReservationMain.Business.Dtos.TheaterDtos;
using CinemaReservationMain.Business.Services.Interfaces;
using CinemaReservationMain.Core.Models;
using CinemaReservationMain.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservationMain.Business.Services.Implementations
{
    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _theaterRepository;
        private readonly IMapper _mapper;

        public TheaterService(ITheaterRepository theaterRepository, IMapper mapper)
        {
            _theaterRepository = theaterRepository;
            _mapper = mapper;
        }
        public async Task<TheaterGetDto> CreateAsync(TheaterCreateDto dto)
        {
            var theater = _mapper.Map<Theater>(dto);
            theater.CreatedDate = DateTime.Now;
            theater.UpdatedDate = DateTime.Now;

            await _theaterRepository.CreateAsync(theater);
            await _theaterRepository.CommitAsync();

            return _mapper.Map<TheaterGetDto>(theater);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new Exception();

            var theater = await _theaterRepository.GetByIdAsync(id);
            if (theater == null) throw new Exception("Theater not found.");

            theater.IsDeleted = true;
            await _theaterRepository.CommitAsync();
        }

        public async Task<ICollection<TheaterGetDto>> GetByExpression(bool asnotracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes)
        {
            var theaters = await _theaterRepository.GetByExpression(asnotracking, expression, includes).ToListAsync();

            return _mapper.Map<ICollection<TheaterGetDto>>(theaters);
        }

        public async Task<TheaterGetDto> GetById(int id)
        {
            if (id < 1) throw new Exception();

            var theater = await _theaterRepository.GetByIdAsync(id);
            if (theater == null) throw new Exception("Theater not found");

            return _mapper.Map<TheaterGetDto>(theater);
        }

        public async Task<TheaterGetDto> GetSingleByExpression(bool asnotracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes)
        {
            var theater = await _theaterRepository.GetByExpression(asnotracking, expression, includes).FirstOrDefaultAsync();
            if (theater == null) throw new Exception("Theater not found");

            return _mapper.Map<TheaterGetDto>(theater);
        }

        public async Task UpdateAsync(int? id, TheaterUpdateDto dto)
        {
            if (id < 1 || id is null) throw new NullReferenceException("id is invalid");

            var theater = await _theaterRepository.GetByIdAsync((int)id);
            if (theater == null) throw new Exception("Theater not found");

            _mapper.Map(dto, theater);

            theater.UpdatedDate = DateTime.Now;

            await _theaterRepository.CommitAsync();
        }
    }
}
