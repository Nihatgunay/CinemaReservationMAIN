using System.Linq.Expressions;
using AutoMapper;
using CinemaReservationMain.Business.Dtos.ReservationDtos;
using CinemaReservationMain.Business.Services.Interfaces;
using CinemaReservationMain.Core.Models;
using CinemaReservationMain.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservationMain.Business.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }
        public async Task<ReservationGetDto> CreateAsync(ReservationCreateDto dto)
        {
            var reservation = _mapper.Map<Reservation>(dto);
            reservation.ReservationDate = DateTime.Now;
            reservation.CreatedDate = DateTime.Now;
            reservation.UpdatedDate = DateTime.Now;

            await _reservationRepository.CreateAsync(reservation);
            await _reservationRepository.CommitAsync();
            return _mapper.Map<ReservationGetDto>(reservation);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new Exception();

            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null) throw new Exception("Reservation not found.");

            _reservationRepository.Delete(reservation);
            await _reservationRepository.CommitAsync();
        }

        public async Task<ICollection<ReservationGetDto>> GetByExpression(bool asnotracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes)
        {
            var reservations = await _reservationRepository.GetByExpression(asnotracking, expression, includes).ToListAsync();

            return _mapper.Map<ICollection<ReservationGetDto>>(reservations);
        }

        public async Task<ReservationGetDto> GetById(int id)
        {
            if (id < 1) throw new Exception();

            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null) throw new Exception("Reservation not found");

            return _mapper.Map<ReservationGetDto>(reservation);
        }

        public async Task<ReservationGetDto> GetSingleByExpression(bool asnotracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes)
        {
            var reservation = await _reservationRepository.GetByExpression(asnotracking, expression, includes).FirstOrDefaultAsync();
            if (reservation == null) throw new Exception("Reservation not found");

            return _mapper.Map<ReservationGetDto>(reservation);
        }

        public async Task UpdateAsync(int? id, ReservationUpdateDto dto)
        {
            if (id < 1 || id is null) throw new NullReferenceException("id is invalid");

            var reservation = await _reservationRepository.GetByIdAsync((int)id);
            if (reservation == null) throw new Exception("Reservation not found");

            _mapper.Map(dto, reservation);

            reservation.UpdatedDate = DateTime.Now;

            await _reservationRepository.CommitAsync();
        }
    }
}
