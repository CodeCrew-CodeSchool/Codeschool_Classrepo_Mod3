using System.Threading.Tasks;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models.Services
{
	public class CastService
	{
		private TestDbContext _testDbContext;

		public CastService(TestDbContext testDbContext)
		{
			_testDbContext = testDbContext;
		}

		public async Task<Cast> Create(Cast cast)
		{
			_testDbContext.Entry(cast).State = EntityState.Added;
			await _testDbContext.SaveChangesAsync();
			return cast;

		}
	}
}
