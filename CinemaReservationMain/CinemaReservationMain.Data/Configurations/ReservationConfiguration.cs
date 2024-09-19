using CinemaReservationMain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaReservationMain.Data.Configurations
{
	public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
	{
		public void Configure(EntityTypeBuilder<Reservation> builder)
		{
			builder.HasOne(x=>x.AppUser).WithMany(x=>x.Reservations).HasForeignKey(x=>x.AppUserId).OnDelete(DeleteBehavior.Cascade);

		}
	}
}
