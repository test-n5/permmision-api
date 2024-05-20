using PermissionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PermissionApi.Services
{
    public class PermissionServices
    {
        private readonly PermissionDbContext _context;

        public PermissionServices(PermissionDbContext context)
        {
            _context = context;
        }

        public async Task<List<Permission>> GetPermissionsAsync()
        {
            return await _context.Permissions.Include(p => p.PermissionType).ToListAsync();
        }

        public async Task<Permission?> GetPermissionByIdAsync(int id)
        {
            return await _context.Permissions.Include(p => p.PermissionType)
                                             .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreatePermissionAsync(Permission permission)
        {
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
        }
    }
}
