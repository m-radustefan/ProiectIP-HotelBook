/**************************************************************************
 *                                                                        *
 *  File:        SqliteEmployeeRepository.cs                              *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Implementare concretă a IEmployeeRepository care utilizează*
 *  SQLite pentru stocarea persistentă a datelor angajaților.             *
 *  Caracteristici principale:                                            *
 *    - Inițializează baza de date și tabela Employees la creare          *
 *    - Implementează operațiile CRUD pentru gestionarea angajaților      *
 *    - Utilizează parametri SQL pentru prevenirea SQL injection          *
 *    - Gestionează corect resursele prin blocuri using                   *
 *  Clasa este sealed pentru a preveni moștenirea nedorită.               *
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
using HotelBook.Domain;
using System.Data;

using System.Data.SQLite;
using System.IO;

namespace HotelBook.Data
{
    public sealed class SqliteEmployeeRepository : IEmployeeRepository
    {
        private readonly string _connString;

        // Constructor - primeste calea catre fisierul bazei de date SQLite
        public SqliteEmployeeRepository(string dbPath)
        {
            _connString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
        }

        // Creeaza tabela Employees daca nu exista deja.
        private void InitializeDatabase()
        {
            using (var conn = new SQLiteConnection(_connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Employees (
                    Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT    NOT NULL,
                    LastName  TEXT    NOT NULL,
                    Username  TEXT    NOT NULL UNIQUE,
                    Password  TEXT    NOT NULL,
                    Role      TEXT    NOT NULL
                    );";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Returneaza toti angajatii din baza de date.
        public IEnumerable<Employee> GetAll()
        {
            var list = new List<Employee>();
            using (var conn = new SQLiteConnection(_connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id,FirstName,LastName,Username,Password,Role FROM Employees;";
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(new Employee
                            {
                                Id = rdr.GetInt32(0),
                                FirstName = rdr.GetString(1),
                                LastName = rdr.GetString(2),
                                Username = rdr.GetString(3),
                                Password = rdr.GetString(4),
                                Role = (Role)Enum.Parse(typeof(Role), rdr.GetString(5), true)
                            });
                        }
                    }
                }
            }
            return list;
        }

        // Adauga un angajat nou in baza de date.
        public void Add(Employee emp)
        {
            using (var conn = new SQLiteConnection(_connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Employees (FirstName,LastName,Username,Password,Role)
                    VALUES (@f,@l,@u,@p,@r);";
                    cmd.Parameters.AddWithValue("@f", emp.FirstName);
                    cmd.Parameters.AddWithValue("@l", emp.LastName);
                    cmd.Parameters.AddWithValue("@u", emp.Username);
                    cmd.Parameters.AddWithValue("@p", emp.Password);
                    cmd.Parameters.AddWithValue("@r", emp.Role.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Sterge un angajat dupa ID.
        public void Remove(int id)
        {
            using (var conn = new SQLiteConnection(_connString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Employees WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
