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
    public static class RoomService
    {
        private static readonly IRoomRepository _repo;

        static RoomService()
        {
            // folosim același DB file ca pentru angajați; tabela Rooms e separată
            string dbFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "employees.db"
            );
            _repo = new SqliteRoomRepository(dbFile);
        }

        public static IEnumerable<Room> GetAll() => _repo.GetAll();
        public static void Update(Room r) => _repo.Update(r);
        public static void Add(Room r) => _repo.Add(r);   // ← nou
    }
}

