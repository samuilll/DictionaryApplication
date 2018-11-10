namespace Dictionary.Models
{
    public class UsersWords
    {
        public string UserId { get; set; }

        public int WordId { get; set; }

        public User User { get; set; }

        public Word Word { get; set; }
    }
}