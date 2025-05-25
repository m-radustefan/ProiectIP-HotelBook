/**************************************************************************
 *                                                                        *
 *  File:        EmployeeService.cs                                        *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Acest fișier definește clasa statică EmployeeService,    *
 *  care oferă metode pentru gestionarea angajaților unui hotel.           *
 *  Serviciul utilizează un repository SQLite pentru stocarea persistentă  *
 *  a datelor și expune metode pentru obținerea tuturor angajaților,      *
 *  adăugarea unui angajat nou și ștergerea unui angajat existent.        *
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
using HotelBook.Services;
using HotelBook.Domain;
using HotelBook.Data;
using System.IO;

namespace HotelBook.Services
{
    public static class EmployeeService
    {
        private static readonly IEmployeeRepository _repo;

        static EmployeeService()
        {
            string dbFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "employees.db"
            );
            _repo = new SqliteEmployeeRepository(dbFile);
        }

        public static IEnumerable<Employee> GetAll() => _repo.GetAll();
        public static void Add(Employee e) => _repo.Add(e);
        public static void Remove(int id) => _repo.Remove(id);
    }
}
