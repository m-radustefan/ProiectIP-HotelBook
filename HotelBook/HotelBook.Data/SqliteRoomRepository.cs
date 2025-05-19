using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using HotelBook.Domain;
using HotelBook.Data;
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
                // Adăugăm coloana Price în CREATE
                cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Rooms (
                Id     INTEGER PRIMARY KEY AUTOINCREMENT,
                Type   TEXT    NOT NULL,
                Status TEXT    NOT NULL,
                Price  REAL    NOT NULL DEFAULT 0
                );";
                cmd.ExecuteNonQuery();
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
                // Selectăm și prețul
                cmd.CommandText = "SELECT Id,Type,Status,Price FROM Rooms;";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Room
                        {
                            Id = r.GetInt32(0),
                            Type = r.GetString(1),
                            Status = (RoomStatus)Enum.Parse(
                                         typeof(RoomStatus),
                                         r.GetString(2),
                                         true
                                     ),
                            Price = r.GetDouble(3)    // ← nou
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
        using (var c = new SQLiteConnection(_cs))
        {
            c.Open();
            using (var cmd = c.CreateCommand())
            {
                // Inserăm și prețul
                cmd.CommandText = @"
                INSERT INTO Rooms (Type,Status,Price)
                VALUES (@t,@s,@p);";
                cmd.Parameters.AddWithValue("@t", room.Type);
                cmd.Parameters.AddWithValue("@s", room.Status.ToString());
                cmd.Parameters.AddWithValue("@p", room.Price);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
