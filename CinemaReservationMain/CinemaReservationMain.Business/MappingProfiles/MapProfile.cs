using AutoMapper;
using CinemaReservationMain.Business.Dtos.TheaterDtos;
using CinemaReservationMain.Core.Models;

namespace CinemaReservationMain.Business.MappingProfiles
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<TheaterCreateDto, Theater>().ReverseMap();
			CreateMap<TheaterUpdateDto, Theater>().ReverseMap();
			CreateMap<TheaterGetDto, Theater>().ReverseMap();

			//CreateMap<Genre, GenreGetDto>().ReverseMap();
			//CreateMap<GenreCreateDto, Genre>().ReverseMap();
			//CreateMap<GenreUpdateDto, Genre>().ReverseMap();

			//CreateMap<MovieImageGetDto, MovieImage>().ReverseMap();

			//CreateMap<CommentGetDto, Comment>().ReverseMap();
			//CreateMap<CommentCreateDto, Comment>().ReverseMap();
			//CreateMap<CommentUpdateDto, Comment>().ReverseMap();
		}
	}
}
