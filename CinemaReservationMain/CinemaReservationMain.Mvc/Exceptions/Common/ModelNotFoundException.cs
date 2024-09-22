namespace CinemaReservationMain.Mvc.Exceptions.Common
{
	public class ModelNotFoundException : Exception
	{
		public ModelNotFoundException()
		{
		}

		public ModelNotFoundException(string? message) : base(message)
		{
		}
	}
}
