using System.ComponentModel.DataAnnotations;

namespace PermissionApi.Models


{
    public class PermissionType
    {
        public int Id { get; set; }
        public required string Description { get; set; }

    }
}
