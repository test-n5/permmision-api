using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionApi.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required DateTime DatePermission { get; set; }

        [ForeignKey("PermissionTypeId")]
        public int PermissionTypeId { get; set; }
        public PermissionType? PermissionType { get; set; }
    }
}