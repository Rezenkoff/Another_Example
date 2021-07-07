using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monitor.DAL.Models
{
    [NotMapped]
    public class AutodocRole : IdentityRole<int>
    {
        public AutodocRole() : base()
        {
        }

        public AutodocRole(string roleName)
        {
            Name = roleName;
        }
    }
}
