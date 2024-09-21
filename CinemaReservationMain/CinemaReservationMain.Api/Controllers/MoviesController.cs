using CinemaReservationMain.Api.ApiResponses;
using CinemaReservationMain.Business.Dtos.MovieDtos;
using CinemaReservationMain.Business.Dtos.MovieDtos;
using CinemaReservationMain.Business.Services.Implementations;
using CinemaReservationMain.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponse<ICollection<MovieGetDto>>
            {
                Data = await _movieService.GetByExpression(true, null, "ShowTimes"),
                ErrorMessage = null,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateDto dto)
        {
            MovieGetDto Movie = null;
            try
            {
                Movie = await _movieService.CreateAsync(dto);
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
            MovieGetDto dto = null;
            try
            {
                dto = await _movieService.GetSingleByExpression(false, x => x.Id == id, "ShowTimes");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(new ApiResponse<MovieGetDto>
            {
                Data = dto,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MovieUpdateDto dto)
        {

            try
            {
                await _movieService.UpdateAsync(id, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<MovieUpdateDto>
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
                await _movieService.DeleteAsync(id);
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
