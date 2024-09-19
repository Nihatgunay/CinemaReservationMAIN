using CinemaReservationMain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaReservationMain.Data.Configurations
{
	public class SeatReservationConfiguration : IEntityTypeConfiguration<SeatReservation>
	{
		public void Configure(EntityTypeBuilder<SeatReservation> builder)
		{
			builder.HasOne(x=>x.ShowTime).WithMany(X=>X.SeatReservations).HasForeignKey(x=>x.ShowTimeId).OnDelete(DeleteBehavior.Cascade);

		}
	}
}
