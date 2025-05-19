using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HotelBook.Domain
{
    public sealed class Room
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public RoomStatus Status { get; set; }
        public double Price { get; set; }    // ← nou
    }
}

