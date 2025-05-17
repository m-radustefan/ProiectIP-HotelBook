using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using HotelBook.Domain;

namespace HotelBook.Data
{
    public sealed class SqliteRoomRepository : IRoomRepository
    {
        private readonly string _cs;

        public SqliteRoomRepository(string dbPath)
        {
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
                    CREATE TABLE IF NOT EXISTS Rooms (
                    Id     INTEGER PRIMARY KEY,
                    Type   TEXT    NOT NULL,
                    Status TEXT    NOT NULL
                    );";
                    cmd.ExecuteNonQuery();
                }
                // dacă nu există camere, adaugă‐le pe cele implicite
                using (var cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Rooms;";
                    long cnt = (long)cmd.ExecuteScalar();
                    if (cnt == 0)
                    {
                        var types = new[] { "Single", "Double", "Suite" };
                        foreach (var t in types)
                        {
                            cmd.CommandText = "INSERT INTO Rooms(Id,Type,Status) VALUES(NULL,@t,@s);";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@t", t);
                            cmd.Parameters.AddWithValue("@s", RoomStatus.ReadyToBook.ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public IEnumerable<Room> GetAll()
        {
            var list = new List<Room>();
            using (var c = new SQLiteConnection(_cs))
            {
                c.Open();
                using (var cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id,Type,Status FROM Rooms;";
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new Room
                            {
                                Id = r.GetInt32(0),
                                Type = r.GetString(1),
                                Status = (RoomStatus)Enum.Parse(typeof(RoomStatus), r.GetString(2), true)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Update(Room room)
        {
            using (var c = new SQLiteConnection(_cs))
            {
                c.Open();
                using (var cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Rooms SET Status=@s WHERE Id=@id;";
                    cmd.Parameters.AddWithValue("@s", room.Status.ToString());
                    cmd.Parameters.AddWithValue("@id", room.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Add(Room room)
        {
            using (var conn = new SQLiteConnection(_cs))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Rooms (Type, Status)
                    VALUES (@t, @s);";
                    cmd.Parameters.AddWithValue("@t", room.Type);
                    cmd.Parameters.AddWithValue("@s", room.Status.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
