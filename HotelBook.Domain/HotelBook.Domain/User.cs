using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBook.Domain
{
    public sealed class User
    {
        public string Username { get; }
        public Role Role { get; }

        public User(string username, Role role)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Role = role;
        }
    }
}
