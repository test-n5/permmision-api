using PermissionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PermissionApi.Services
{
    /// <summary>
    /// Service class for managing permissions.
    /// </summary>
    public class PermissionServices
    {
        private readonly PermissionDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionServices"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PermissionServices(PermissionDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of all permissions asynchronously.
        /// </summary>
        /// <returns>A list of permissions.</returns>
        public async Task<List<Permission>> GetPermissionsAsync()
        {
            return await _context.Permissions
                .Include(p => p.PermissionType)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific permission by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the permission to retrieve.</param>
        /// <returns>The permission if found; otherwise, null.</returns>
        public async Task<Permission?> GetPermissionByIdAsync(int id)
        {
            return await _context.Permissions
                .Include(p => p.PermissionType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Creates a new permission asynchronously.
        /// </summary>
        /// <param name="permission">The permission to create.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CreatePermissionAsync(Permission permission)
        {
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing permission asynchronously.
        /// </summary>
        /// <param name="id">The ID of the permission to update.</param>
        /// <param name="updatedPermission">The updated permission details.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public async Task<bool> UpdatePermissionAsync(int id, Permission updatedPermission)
        {
            var existingPermission = await _context.Permissions.FindAsync(id);
            if (existingPermission == null)
            {
                return false;
            }

            existingPermission.Name = updatedPermission.Name;
            existingPermission.LastName = updatedPermission.LastName;
            existingPermission.DatePermission = updatedPermission.DatePermission;
            existingPermission.PermissionTypeId = updatedPermission.PermissionTypeId;

            _context.Permissions.Update(existingPermission);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
