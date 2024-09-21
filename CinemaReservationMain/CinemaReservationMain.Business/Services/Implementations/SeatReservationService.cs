using CinemaReservationMain.Business.Dtos.ReservationDtos;
using System.Linq.Expressions;
using CinemaReservationMain.Business.Services.Interfaces;
using CinemaReservationMain.Core.Models;
using AutoMapper;
using CinemaReservationMain.Core.Repositories;
using CinemaReservationMain.Business.Dtos.SeatReservationDtos;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservationMain.Business.Services.Implementations
{
    public class SeatReservationService : ISeatReservationService
    {
        private readonly IMapper _mapper;
        private readonly ISeatReservationRepository _seatReservationRepository;

        public SeatReservationService(IMapper mapper, ISeatReservationRepository seatReservationRepository)
        {
            _mapper = mapper;
            _seatReservationRepository = seatReservationRepository;
        }
        public async Task<SeatReservationGetDto> CreateAsync(SeatReservationCreateDto dto)
        {
            var seatreservation = _mapper.Map<SeatReservation>(dto);
            seatreservation.IsBooked = false;
            seatreservation.CreatedDate = DateTime.Now;
            seatreservation.UpdatedDate = DateTime.Now;

            await _seatReservationRepository.CreateAsync(seatreservation);
            await _seatReservationRepository.CommitAsync();
            return _mapper.Map<SeatReservationGetDto>(seatreservation);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new Exception();

            var seatreservation = await _seatReservationRepository.GetByIdAsync(id);
            if (seatreservation == null) throw new Exception("Reservation not found.");

            _seatReservationRepository.Delete(seatreservation);
            await _seatReservationRepository.CommitAsync();
        }

        public async Task<ICollection<SeatReservationGetDto>> GetByExpression(bool asnotracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes)
        {
            var reservations = await _seatReservationRepository.GetByExpression(asnotracking, expression, includes).ToListAsync();

            return _mapper.Map<ICollection<SeatReservationGetDto>>(reservations);
        }

        public async Task<SeatReservationGetDto> GetById(int id)
        {
            if (id < 1) throw new Exception();

            var seatreservation = await _seatReservationRepository.GetByIdAsync(id);
            if (seatreservation == null) throw new Exception("Reservation not found");

            return _mapper.Map<SeatReservationGetDto>(seatreservation);
        }

        public async Task<SeatReservationGetDto> GetSingleByExpression(bool asnotracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes)
        {
            var seatreservation = await _seatReservationRepository.GetByExpression(asnotracking, expression, includes).FirstOrDefaultAsync();
            if (seatreservation == null) throw new Exception("Reservation not found");

            return _mapper.Map<SeatReservationGetDto>(seatreservation);
        }

        public async Task UpdateAsync(int? id, SeatReservationUpdateDto dto)
        {
            if (id < 1 || id is null) throw new NullReferenceException("id is invalid");

            var seatreservation = await _seatReservationRepository.GetByIdAsync((int)id);
            if (seatreservation == null) throw new Exception("Reservation not found");

            _mapper.Map(dto, seatreservation);

            seatreservation.UpdatedDate = DateTime.Now;

            await _seatReservationRepository.CommitAsync();
        }
    }
}
