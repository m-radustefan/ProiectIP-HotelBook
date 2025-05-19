using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using HotelBook.Domain;

namespace HotelBook.Data
{
    public sealed class SqliteReservationRepository : IReservationRepository
    {
        private readonly string _cs;

        public SqliteReservationRepository(string dbPath)
        {
            if (string.IsNullOrWhiteSpace(dbPath))
                throw new ArgumentException("Path cannot be empty.", nameof(dbPath));

            _cs = $"Data Source={dbPath};Version=3;";
            Initialize();
        }

        private void Initialize()
        {
            using (var c = new SQLiteConnection(_cs))
            {
                c.Open();
                using (var cmd = c.CreateCommand())
                {
                    cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Reservations (
                    Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomId    INTEGER NOT NULL,
                    RoomType  TEXT    NOT NULL,
                    Nights    INTEGER NOT NULL,
                    FirstName TEXT    NOT NULL,
                    LastName  TEXT    NOT NULL,
                    Phone     TEXT    NOT NULL,
                    Email     TEXT    NOT NULL
                    );";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Reservation> GetAll()
        {
            var list = new List<Reservation>();

            using (var c = new SQLiteConnection(_cs))
            {
                c.Open();
                using (var cmd = c.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT 
                    Id,
                    RoomId,
                    RoomType,
                    Nights,
                    FirstName,
                    LastName,
                    Phone,
                    Email
                    FROM Reservations;";
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new Reservation
                            {
                                Id = r.GetInt32(0),
                                RoomId = r.GetInt32(1),
                                RoomType = r.GetString(2),
                                Nights = r.GetInt32(3),
                                FirstName = r.GetString(4),
                                LastName = r.GetString(5),
                                Phone = r.GetString(6),
                                Email = r.GetString(7)
                            });
                        }
                    }
                }
            }

            return list;
        }

        public void Add(Reservation r)
        {
            if (r == null) throw new ArgumentNullException(nameof(r));

            using (var c = new SQLiteConnection(_cs))
            {
                c.Open();
                using (var cmd = c.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Reservations
                        (RoomId,RoomType,Nights,FirstName,LastName,Phone,Email)
                    VALUES
                        (@rid,@type,@n,@f,@l,@p,@e);";
                    cmd.Parameters.AddWithValue("@rid", r.RoomId);
                    cmd.Parameters.AddWithValue("@type", r.RoomType);
                    cmd.Parameters.AddWithValue("@n", r.Nights);
                    cmd.Parameters.AddWithValue("@f", r.FirstName);
                    cmd.Parameters.AddWithValue("@l", r.LastName);
                    cmd.Parameters.AddWithValue("@p", r.Phone);
                    cmd.Parameters.AddWithValue("@e", r.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveByRoom(int roomId)
        {
            using (var c = new SQLiteConnection(_cs))
            {
                c.Open();
                using (var cmd = c.CreateCommand())
                {
                    cmd.CommandText = @"
                    DELETE FROM Reservations
                    WHERE RoomId = @rid;";
                    cmd.Parameters.AddWithValue("@rid", roomId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
