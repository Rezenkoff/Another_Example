using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Monitor.Models
{
    public class AutodocUser : IdentityUser<int>
    {
        [Required]
        public string FirstLastName { get; set; }

        public bool IsAgreed { get; set; }

        public int? BitrixId { get; set; }
    }
}
