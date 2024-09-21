using AutoMapper;
using CinemaReservationMain.Business.Dtos.MovieDtos;
using CinemaReservationMain.Business.Dtos.ReservationDtos;
using CinemaReservationMain.Business.Dtos.SeatReservationDtos;
using CinemaReservationMain.Business.Dtos.ShowTimeDtos;
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

            CreateMap<MovieCreateDto, Movie>().ReverseMap();
            CreateMap<MovieUpdateDto, Movie>().ReverseMap();
            CreateMap<MovieGetDto, Movie>().ReverseMap();

            CreateMap<ShowTimeCreateDto, ShowTime>().ReverseMap();
            CreateMap<ShowTimeUpdateDto, ShowTime>().ReverseMap();
            CreateMap<ShowTimeGetDto, ShowTime>().ReverseMap();

            CreateMap<ReservationCreateDto, Reservation>().ReverseMap();
            CreateMap<ReservationUpdateDto, Reservation>().ReverseMap();
            CreateMap<ReservationGetDto, Reservation>().ReverseMap();

            CreateMap<SeatReservationCreateDto, SeatReservation>().ReverseMap();
            CreateMap<SeatReservationUpdateDto, SeatReservation>().ReverseMap();
            CreateMap<SeatReservationGetDto, SeatReservation>().ReverseMap();
        }
	}
}
