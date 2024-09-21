using CinemaReservationMain.Api.ApiResponses;
using CinemaReservationMain.Business.Dtos.ReservationDtos;
using CinemaReservationMain.Business.Dtos.SeatReservationDtos;
using CinemaReservationMain.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatReservationsController : ControllerBase
    {
        private readonly ISeatReservationService _seatReservationService;

        public SeatReservationsController(ISeatReservationService seatReservationService)
        {
            _seatReservationService = seatReservationService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponse<ICollection<SeatReservationGetDto>>
            {
                Data = await _seatReservationService.GetByExpression(true, null),
                ErrorMessage = null,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SeatReservationCreateDto dto)
        {
            SeatReservationGetDto Reservation = null;
            try
            {
                Reservation = await _seatReservationService.CreateAsync(dto);
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
            SeatReservationGetDto dto = null;
            try
            {
                dto = await _seatReservationService.GetSingleByExpression(false, x => x.Id == id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(new ApiResponse<SeatReservationGetDto>
            {
                Data = dto,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SeatReservationUpdateDto dto)
        {

            try
            {
                await _seatReservationService.UpdateAsync(id, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatReservationUpdateDto>
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
                await _seatReservationService.DeleteAsync(id);
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
