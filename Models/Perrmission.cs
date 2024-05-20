using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionApi.Models
{
    /// <summary>
    /// Represents a permission entity.
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// Gets or sets the unique identifier for the permission.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the permission.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name associated with the permission.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Gets or sets the date the permission was granted.
        /// </summary>
        public required DateTime DatePermission { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the permission type.
        /// </summary>
        [ForeignKey("PermissionTypeId")]
        public int PermissionTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the permission.
        /// </summary>
        public PermissionType? PermissionType { get; set; }
    }
}
