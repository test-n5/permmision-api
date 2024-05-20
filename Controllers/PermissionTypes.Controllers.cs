using Microsoft.AspNetCore.Mvc;
using PermissionApi.Services;
using PermissionApi.Models;

namespace PermissionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionTypeController(PermissionTypeService permissionTypeService) : ControllerBase
    {
        private readonly PermissionTypeService _permissionTypeService = permissionTypeService;

        [HttpGet]
        public async Task<ActionResult<List<PermissionType>>> Get()
        {
            var permissionTypes = await _permissionTypeService.GetPermissionTypesAsync();

            if (permissionTypes == null || permissionTypes.Count == 0)
            {
                return NotFound("No permission types found.");
            }
            return Ok(permissionTypes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionType>> GetById(int id)
        {
            var permissionType = await _permissionTypeService.GetPermissionTypeByIdAsync(id);
            if (permissionType == null)
            {
                return NotFound($"Permission type with ID {id} not found.");
            }
            return Ok(permissionType);
        }
    }
}
