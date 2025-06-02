/**************************************************************************
 *                                                                        *
 *  File:        ReservationService.cs                                    *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-ionut.padurariu@student.tuiasi.ro                  *
 *  Description: Acest fișier definește clasa statică ReservationService, *
 *  care oferă metode pentru gestionarea rezervărilor unui hotel.         *
 *  Serviciul utilizează un repository SQLite pentru stocarea persistentă *
 *  a datelor și expune metode pentru:                                    *
 *    - Obținerea tuturor rezervărilor                                    *
 *    - Adăugarea unei noi rezervări                                      *
 *    - Ștergerea rezervărilor după numărul camerei                       *
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
    public static class ReservationService
    {
        private static readonly IReservationRepository _repo;

        // Constructor static ce inițializează repository-ul SQLite pentru rezervări
        static ReservationService()
        {
            string dbFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employees.db");
            _repo = new SqliteReservationRepository(dbFile);
        }

        // Returnează toate rezervările existente din baza de date
        public static IEnumerable<Reservation> GetAll() => _repo.GetAll();

        // Adaugă o nouă rezervare în baza de date
        public static void Add(Reservation r) => _repo.Add(r);

        // Șterge toate rezervările asociate unei camere după ID-ul camerei
        public static void RemoveByRoom(int roomId) => _repo.RemoveByRoom(roomId);

      
    }
}
