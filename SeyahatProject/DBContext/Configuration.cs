
namespace SeyahatProject.DBContext
{
	static class Configuration
	{
		static public string ConnectionString
		{
			get
			{
				ConfigurationManager configurationManager= new ConfigurationManager ();
				configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SeyahatProject"));
				configurationManager.AddJsonFile("appsettings.json"); 
				

				return configurationManager.GetConnectionString("PostgreSQL");
			}
		}
	}
}
