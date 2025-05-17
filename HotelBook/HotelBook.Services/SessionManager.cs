using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelBook.Domain;

namespace HotelBook.Services
{
    public static class SessionManager
    {
        public static User CurrentUser { get; private set; }

        public static void Login(User user)
        {
            CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
        }

        public static void Logout() => CurrentUser = null;

        public static bool IsLoggedIn => CurrentUser != null;
    }
}