using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication2.Models.Interfaces
{
	public interface ICast
	{
		// CREATE
		Task<Cast> Create(Cast cast);

		// GET ALL

		Task<List<Cast>> GetCasts();

		// GET ONE BY ID
		Task<Cast> GetCast(int id);

		// UPDATE
		Task<Cast> UpdateCast(int id, Cast cast);

		// DELETE
		Task Delete(int id);
	}
}
