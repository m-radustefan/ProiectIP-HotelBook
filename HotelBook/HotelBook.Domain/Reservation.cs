using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBook.Domain
{
    public sealed class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public int Nights { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
