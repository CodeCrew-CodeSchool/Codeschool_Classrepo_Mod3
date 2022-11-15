using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
	public class Cast
	{
		public int Id { get; set; }

		public string ShowId { get; set; }
		public string ShowName { get; set; }

		public string JobTitle { get; set; }

		public int PersonId { get; set; }
		public string PersonName { get; set; }
	}
}
