using AutoMapper;
using CinemaReservationMain.Business.Dtos.ShowTimeDtos;
using CinemaReservationMain.Business.Services.Interfaces;
using CinemaReservationMain.Core.Models;
using CinemaReservationMain.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaReservationMain.Business.Services.Implementations
{
    public class ShowTimeService : IShowTimeService
    {
        private readonly IShowTimeRepository _showsimeRepository;
        private readonly IMapper _mapper;

        public ShowTimeService(IShowTimeRepository ShowTimeRepository, IMapper mapper)
        {
            _showsimeRepository = ShowTimeRepository;
            _mapper = mapper;
        }
        public async Task<ShowTimeGetDto> CreateAsync(ShowTimeCreateDto dto)
        {
            var showtime = _mapper.Map<ShowTime>(dto);
            showtime.CreatedDate = DateTime.Now;
            showtime.UpdatedDate = DateTime.Now;

            await _showsimeRepository.CreateAsync(showtime);
            await _showsimeRepository.CommitAsync();

            return _mapper.Map<ShowTimeGetDto>(showtime);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new Exception();

            var showtime = await _showsimeRepository.GetByIdAsync(id);
            if (showtime == null) throw new Exception("ShowTime not found.");

            _showsimeRepository.Delete(showtime);
            await _showsimeRepository.CommitAsync();
        }

        public async Task<ICollection<ShowTimeGetDto>> GetByExpression(bool asnotracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes)
        {
            var showtimes = await _showsimeRepository.GetByExpression(asnotracking, expression, includes).ToListAsync();

            return _mapper.Map<ICollection<ShowTimeGetDto>>(showtimes);
        }

        public async Task<ShowTimeGetDto> GetById(int id)
        {
            if (id < 1) throw new Exception();

            var showtime = await _showsimeRepository.GetByIdAsync(id);
            if (showtime == null) throw new Exception("ShowTime not found");

            return _mapper.Map<ShowTimeGetDto>(showtime);
        }

        public async Task<ShowTimeGetDto> GetSingleByExpression(bool asnotracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes)
        {
            var showtime = await _showsimeRepository.GetByExpression(asnotracking, expression, includes).FirstOrDefaultAsync();
            if (showtime == null) throw new Exception("Showtime not found");

            return _mapper.Map<ShowTimeGetDto>(showtime);
        }

        public async Task UpdateAsync(int? id, ShowTimeUpdateDto dto)
        {
            if (id < 1 || id is null) throw new NullReferenceException("id is invalid");

            var showtime = await _showsimeRepository.GetByIdAsync((int)id);
            if (showtime == null) throw new Exception("ShowTime not found");

            _mapper.Map(dto, showtime);

            showtime.UpdatedDate = DateTime.Now;

            await _showsimeRepository.CommitAsync();
        }
    }
}
