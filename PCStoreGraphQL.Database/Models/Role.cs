using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace PCStoreGraphQL.Database.Models
{
    public class Role : IdentityRole<int>
    {
        public Role(string roleName) : base(roleName)
        {
        }

        public string RoleName { get; set; } = null!;
    }
}
