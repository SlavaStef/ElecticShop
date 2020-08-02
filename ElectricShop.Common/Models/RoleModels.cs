using ElectricShop.Common.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectricShop.Common.Models
{
    public class RoleEditModel
    {
        public AppRole Role { get; set; }
        public IEnumerable<UserDTO> Members { get; set; }
        public IEnumerable<UserDTO> NonMembers { get; set; }
    }

    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}
