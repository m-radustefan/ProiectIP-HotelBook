/**************************************************************************
 *                                                                        *
 *  File:        SqliteRoomRepository.cs                                  *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Acest fișier definește clasa SqliteRoomRepository, care  *
 *  gestionează camerele disponibile într-un hotel, folosind o bază de    *
 *  date SQLite. Clasa permite adăugarea, actualizarea, ștergerea și      *
 *  listarea camerelor, incluzând informații despre tip, status și preț. *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


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

    public void Remove(int id)
    {
        using (var c = new SQLiteConnection(_cs))
        {
            c.Open();
            using (var tx = c.BeginTransaction())
            using (var cmd = c.CreateCommand())
            {
                // 1) Şterge camera cu ID-ul respectiv
                cmd.CommandText = "DELETE FROM Rooms WHERE Id = @id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                // 2) Rearanjează PK-urile: scade cu 1 toate Id‐urile mai mari
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Rooms SET Id = Id - 1 WHERE Id > @id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                // 3) Resetează AUTOINCREMENT ca să continue corect
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM sqlite_sequence WHERE name='Rooms';";
                cmd.ExecuteNonQuery();

                tx.Commit();
            }
        }
    }

}
