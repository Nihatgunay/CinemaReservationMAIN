using CinemaReservationMain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaReservationMain.Data.Configurations
{
	public class MovieConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			builder.Property(x => x.Title).IsRequired().HasMaxLength(70);
			builder.Property(x => x.Desc).IsRequired(false).HasMaxLength(700);
			builder.Property(x => x.Genre).IsRequired().HasMaxLength(30);

			builder.HasMany(x => x.ShowTimes).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
