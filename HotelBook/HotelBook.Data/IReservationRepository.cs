using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBook.Domain;

namespace HotelBook.Data
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        void Add(Reservation r);
        void RemoveByRoom(int roomId);
    }
}
