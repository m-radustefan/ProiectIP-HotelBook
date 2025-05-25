/**************************************************************************
 *                                                                        *
 *  File:        RoomService.cs                                           *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Serviciu static pentru gestionarea camerelor hotelului.  *
 *  Utilizează același fișier SQLite ca EmployeeService dar cu tabelă     *
 *  separată pentru camere. Oferă funcționalități complete CRUD:          *
 *    - Obținerea tuturor camerelor                                       *
 *    - Actualizarea informațiilor despre o cameră                        *
 *    - Adăugarea unei camere noi                                         *
 *    - Ștergerea unei camere după ID                                     *
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
        public static void Remove(int id) => _repo.Remove(id);

    }
}

