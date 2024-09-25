using CinemaReservationMain.Api.ApiResponses;
using CinemaReservationMain.Business.Dtos.ReservationDtos;
using CinemaReservationMain.Business.Dtos.SeatReservationDtos;
using CinemaReservationMain.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponse<ICollection<ReservationGetDto>>
            {
                Data = await _reservationService.GetByExpression(true, null, "SeatReservations", "ShowTime"),
                ErrorMessage = null,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateDto dto)
        {
            ReservationGetDto Reservation = null;
            try
            {
                Reservation = await _reservationService.CreateAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }

            return Created();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ReservationGetDto dto = null;
            try
            {
                dto = await _reservationService.GetSingleByExpression(false, x => x.Id == id, "SeatReservations", "ShowTimes");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(new ApiResponse<ReservationGetDto>
            {
                Data = dto,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReservationUpdateDto dto)
        {

            try
            {
                await _reservationService.UpdateAsync(id, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<ReservationUpdateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _reservationService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            return Ok();
        }
    }
}
