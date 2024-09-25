using CinemaReservationMain.Core.Models;

namespace CinemaReservationMain.Business.Services.Interfaces;

public interface ILayoutService
{
    Task<string> GetUser(string username);
}
