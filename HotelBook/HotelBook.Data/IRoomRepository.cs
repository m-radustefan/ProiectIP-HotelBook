using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBook.Domain;

namespace HotelBook.Data
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        void Update(Room room);
        void Add(Room room);
        void Remove(int id);

    }
}
