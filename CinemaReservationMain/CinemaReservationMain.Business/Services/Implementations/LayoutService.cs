using CinemaReservationMain.Business.Services.Interfaces;
using CinemaReservationMain.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace CinemaReservationMain.Business.Services.Implementations;

public class LayoutService : ILayoutService
{
    private readonly UserManager<AppUser> _userManager;

    public LayoutService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> GetUser(string username)
    {
        var user = await _userManager.FindByNameAsync(username);

        return user.UserName;
    }
}
