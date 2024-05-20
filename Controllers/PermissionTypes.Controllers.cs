using Microsoft.AspNetCore.Mvc;
using PermissionApi.Services;
using PermissionApi.Models;

namespace PermissionApi.Controllers
{
    /// <summary>
    /// Controller for managing permission types.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionTypeController : ControllerBase
    {
        private readonly PermissionTypeService _permissionTypeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionTypeController"/> class.
        /// </summary>
        /// <param name="permissionTypeService">The service to manage permission types.</param>
        public PermissionTypeController(PermissionTypeService permissionTypeService)
        {
            _permissionTypeService = permissionTypeService;
        }

        /// <summary>
        /// Gets a list of all permission types.
        /// </summary>
        /// <returns>A list of permission types.</returns>
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

        /// <summary>
        /// Gets a permission type by its ID.
        /// </summary>
        /// <param name="id">The ID of the permission type to retrieve.</param>
        /// <returns>The requested permission type.</returns>
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
