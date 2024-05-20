using Microsoft.EntityFrameworkCore;

namespace PermissionApi
{
    public class DataBaseConnect
    {
        public async Task Conected(PermissionDbContext dbContext)
        {
            await dbContext.Database.EnsureCreatedAsync();
            Console.WriteLine($"Database Online: {dbContext.Database.IsSqlite()}");
        }
    }
}
