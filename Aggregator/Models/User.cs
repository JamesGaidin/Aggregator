using System.Collections.Generic;

namespace Aggregator.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        public string PasswordHash { get; set; } // We'll hash later with BCrypt or similar

        public ICollection<CollectionItem> CollectionItems { get; set; }
    }
}
