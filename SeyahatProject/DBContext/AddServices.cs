using Microsoft.EntityFrameworkCore;

namespace SeyahatProject.DBContext
{
	public static class AddServices
	{
		public static void AddDBServices(this IServiceCollection services)
		{
			services.AddDbContext<Context>(options =>
			options.UseNpgsql(Configuration.ConnectionString));
		}
	}
}
