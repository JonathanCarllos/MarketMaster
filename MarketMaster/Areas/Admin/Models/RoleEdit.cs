using Microsoft.AspNetCore.Identity;

namespace MarketMaster.Areas.Admin.Models
{
    public class RoleEdit
    {
        public IdentityRole? Role { get; set; }
        public IEnumerable<IdentityUser>? Users { get; set; }
        public IEnumerable<IdentityUser>? NonMembers { get; set; }
    }
}
