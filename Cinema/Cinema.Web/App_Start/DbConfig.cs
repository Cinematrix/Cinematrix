using Cinema.Data;
using Cinema.Data.Migrations;
using System.Data.Entity;

namespace Cinema.Web.App_Start
{

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CinemaDbContext, Configuration>());
            CinemaDbContext.Create().Database.Initialize(true);
        }
    }
}