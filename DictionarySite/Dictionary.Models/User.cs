using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Dictionary.Models
{
    public class User:IdentityUser
    {
        public User()
        {
            UserWords = new HashSet<UsersWords>();
        }

        public IEnumerable<UsersWords> UserWords { get; set; }

    }
}
