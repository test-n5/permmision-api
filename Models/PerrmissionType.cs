using System.ComponentModel.DataAnnotations;

namespace PermissionApi.Models
{
    /// <summary>
    /// Represents the type of a permission.
    /// </summary>
    public class PermissionType
    {
        /// <summary>
        /// Gets or sets the unique identifier for the permission type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description of the permission type.
        /// </summary>
        [Required]
        public required string Description { get; set; }
    }
}
