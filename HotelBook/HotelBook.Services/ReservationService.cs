using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HotelBook.Data;
using HotelBook.Domain;

namespace HotelBook.Services
{
    public static class ReservationService
    {
        private static readonly IReservationRepository _repo;

        static ReservationService()
        {
            string dbFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employees.db");
            _repo = new SqliteReservationRepository(dbFile);
        }

        public static IEnumerable<Reservation> GetAll() => _repo.GetAll();
        public static void Add(Reservation r) => _repo.Add(r);
        public static void RemoveByRoom(int roomId) => _repo.RemoveByRoom(roomId);
    }
}
