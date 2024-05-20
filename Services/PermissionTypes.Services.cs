using PermissionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PermissionApi.Services
{
    /// <summary>
    /// Service class for managing permission types.
    /// </summary>
    public class PermissionTypeService
    {
        private readonly PermissionDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionTypeService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PermissionTypeService(PermissionDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of all permission types asynchronously.
        /// </summary>
        /// <returns>A list of permission types.</returns>
        public async Task<List<PermissionType>> GetPermissionTypesAsync()
        {
            return await _context.PermissionTypes.ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific permission type by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the permission type to retrieve.</param>
        /// <returns>The permission type if found; otherwise, null.</returns>
        public async Task<PermissionType?> GetPermissionTypeByIdAsync(int id)
        {
            return await _context.PermissionTypes.FindAsync(id);
        }
    }
}
