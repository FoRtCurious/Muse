using Models;
using System.Runtime.Remoting.Messaging;

namespace DAL
{
    public class DbContextFactory
    {
        public static SingMusicDataBaseEntities CreateDbContext()
        {
            SingMusicDataBaseEntities dbContext = (SingMusicDataBaseEntities)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new SingMusicDataBaseEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
