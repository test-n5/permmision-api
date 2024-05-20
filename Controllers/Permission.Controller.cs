using Microsoft.AspNetCore.Mvc;
using PermissionApi.Services;
using PermissionApi.Models;

namespace PermissionApi.Controllers
{
    /// <summary>
    /// Controller for managing permissions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionServices _permissionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionController"/> class.
        /// </summary>
        /// <param name="permissionService">The service to manage permissions.</param>
        public PermissionController(PermissionServices permissionService)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// Gets a list of all permissions.
        /// </summary>
        /// <returns>A list of permissions.</returns>
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

        /// <summary>
        /// Gets a permission by its ID.
        /// </summary>
        /// <param name="id">The ID of the permission to retrieve.</param>
        /// <returns>The requested permission.</returns>
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

        /// <summary>
        /// Creates a new permission.
        /// </summary>
        /// <param name="permission">The permission to create.</param>
        /// <returns>A response indicating the result of the creation operation.</returns>
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

        /// <summary>
        /// Updates an existing permission.
        /// </summary>
        /// <param name="id">The ID of the permission to update.</param>
        /// <param name="updatedPermission">The updated permission data.</param>
        /// <returns>A response indicating the result of the update operation.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Permission updatedPermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _permissionService.UpdatePermissionAsync(id, updatedPermission);
            if (!success)
            {
                return NotFound($"Permission with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
