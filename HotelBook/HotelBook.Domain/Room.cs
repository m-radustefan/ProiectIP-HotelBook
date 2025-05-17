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
        public string Type { get; set; }      // ex. "Single", "Double", "Suite" etc.
        public RoomStatus Status { get; set; }
    }
}
