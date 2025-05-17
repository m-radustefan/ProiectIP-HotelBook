using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBook.Domain;

namespace HotelBook.Data
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        void Add(Employee emp);
        void Remove(int id);
    }
}