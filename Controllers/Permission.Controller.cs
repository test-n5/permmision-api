using Microsoft.AspNetCore.Mvc;
using PermissionApi.Services;
using PermissionApi.Models;

namespace PermissionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionServices _permissionService;

        public PermissionController(PermissionServices permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Permission>>> Get()
        {
            var permissions = await _permissionService.GetPermissionsAsync();
            if (permissions == null || permissions.Count == 0)
            {
                return NotFound("No permissions found.");
            }
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> GetById(int id)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(id);
            if (permission == null)
            {
                return NotFound($"Permission with ID {id} not found.");
            }
            return Ok(permission);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            permission.Id = 0;

            await _permissionService.CreatePermissionAsync(permission);
            return CreatedAtAction(nameof(GetById), new { id = permission.Id }, permission);
        }
    }
}
