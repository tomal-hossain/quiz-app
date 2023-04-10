using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public IList<Response> Responses { get; set; }
    }
}
