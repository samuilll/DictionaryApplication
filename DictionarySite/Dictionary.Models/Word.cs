using System.Collections.Generic;

namespace Dictionary.Models
{
    public class Word
    {
        public Word()
        {
            this.WordUsers = new HashSet<UsersWords>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<UsersWords> WordUsers { get; set; }
    }
}
