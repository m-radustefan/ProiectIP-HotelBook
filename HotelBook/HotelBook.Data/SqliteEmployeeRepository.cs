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

        public SqliteEmployeeRepository(string dbPath)
        {
            // dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employees.db")
            _connString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
        }

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
