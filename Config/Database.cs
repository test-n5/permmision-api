using Microsoft.EntityFrameworkCore;

namespace PermissionApi
{
    /// <summary>
    /// Class responsible for handling database connection operations.
    /// </summary>
    public class DataBaseConnect
    {
        /// <summary>
        /// Ensures that the database for the provided context is created. If the database 
        /// already exists, no action is taken.
        /// </summary>
        /// <param name="dbContext">The database context to use for the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Conected(PermissionDbContext dbContext)
        {
            await dbContext.Database.EnsureCreatedAsync();
            Console.WriteLine($"Database Online: {dbContext.Database.IsSqlite()}");
        }
    }
}
