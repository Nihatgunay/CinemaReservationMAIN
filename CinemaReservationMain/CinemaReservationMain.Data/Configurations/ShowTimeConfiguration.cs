using CinemaReservationMain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaReservationMain.Data.Configurations
{
	public class ShowTimeConfiguration : IEntityTypeConfiguration<ShowTime>
	{
		public void Configure(EntityTypeBuilder<ShowTime> builder)
		{
			builder.HasMany(x=>x.SeatReservations).WithOne(x=>x.ShowTime).HasForeignKey(x=>x.ShowTimeId).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
