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
