/**************************************************************************
 *                                                                        *
 *  File:        SqliteReservationRepository.cs                           *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Acest fișier definește clasa SqliteReservationRepository,*
 *  care gestionează operațiile CRUD pentru rezervări folosind o bază     *
 *  de date SQLite. Clasa implementează interfața IReservationRepository *
 *  și permite adăugarea, ștergerea și obținerea tuturor rezervărilor.   *
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
using HotelBook.Domain;

namespace HotelBook.Data
{
    // Implementare concreta a IReservationRepository pentru gestionarea rezervarilor cu SQLite.
    // Clasa este sealed pentru a preveni mostenirea nedorita.
    public sealed class SqliteReservationRepository : IReservationRepository
    {
        private readonly string _cs;

        // Constructor care primeste calea catre baza de date si initializeaza conexiunea.
        public SqliteReservationRepository(string dbPath)
        {
            if (string.IsNullOrWhiteSpace(dbPath))
                throw new ArgumentException("Path cannot be empty.", nameof(dbPath));

            _cs = $"Data Source={dbPath};Version=3;";
            Initialize();
        }

        // Creeaza tabela Reservations daca nu exista deja.
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

        // Returneaza lista tuturor rezervarilor din baza de date.
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

        // Adauga o noua rezervare in baza de date.
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

        // Sterge toate rezervarile asociate unei camere, pe baza ID-ului camerei.
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
