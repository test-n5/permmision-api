using PermissionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PermissionApi.Services
{
    public class PermissionTypeService(PermissionDbContext context)
    {
        private readonly PermissionDbContext _context = context;

        public async Task<List<PermissionType>> GetPermissionTypesAsync()
        {
            return await _context.PermissionTypes.ToListAsync();
        }

        public async Task<PermissionType?> GetPermissionTypeByIdAsync(int id)
        {
            return await _context.PermissionTypes.FindAsync(id);
        }
    }
}
