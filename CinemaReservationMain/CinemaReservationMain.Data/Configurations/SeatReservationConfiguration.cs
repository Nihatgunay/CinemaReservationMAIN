using CinemaReservationMain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaReservationMain.Data.Configurations
{
	public class SeatReservationConfiguration : IEntityTypeConfiguration<SeatReservation>
	{
		public void Configure(EntityTypeBuilder<SeatReservation> builder)
		{
			builder.HasOne(x=>x.Reservation).WithMany(x=>x.SeatReservations).HasForeignKey(x=>x.ReservationId).OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(x=>x.Reservation).WithMany(x=>x.SeatReservations).HasForeignKey(x=>x.ShowTimeId).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
