using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Dictionary.Models
{
    public class User:IdentityUser
    {
        public User()
        {
            UserWords = new HashSet<UserWord>();
        }




        public IEnumerable<UserWord> UserWords { get; set; }

    }
}
