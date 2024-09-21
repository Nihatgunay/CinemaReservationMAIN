using CinemaReservationMain.Api.ApiResponses;
using CinemaReservationMain.Business.Dtos.ShowTimeDtos;
using CinemaReservationMain.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimesController : ControllerBase
    {
        private readonly IShowTimeService _ShowTimeService;

        public ShowTimesController(IShowTimeService ShowTimeService)
        {
            _ShowTimeService = ShowTimeService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponse<ICollection<ShowTimeGetDto>>
            {
                Data = await _ShowTimeService.GetByExpression(true, null, "Reservations", "SeatReservations"),
                ErrorMessage = null,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShowTimeCreateDto dto)
        {
            ShowTimeGetDto ShowTime = null;
            try
            {
                ShowTime = await _ShowTimeService.CreateAsync(dto);
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
            ShowTimeGetDto dto = null;
            try
            {
                dto = await _ShowTimeService.GetSingleByExpression(false, x=>x.Id == id, "SeatReservations", "Reservations");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(new ApiResponse<ShowTimeGetDto>
            {
                Data = dto,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ShowTimeUpdateDto dto)
        {

            try
            {
                await _ShowTimeService.UpdateAsync(id, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<ShowTimeUpdateDto>
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
                await _ShowTimeService.DeleteAsync(id);
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
