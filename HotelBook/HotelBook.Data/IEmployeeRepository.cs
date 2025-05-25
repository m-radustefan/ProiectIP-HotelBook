/**************************************************************************
 *                                                                        *
 *  File:        IEmployeeRepository.cs                                   *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Interfață care definește operațiunile de bază pentru     *
 *  gestionarea angajaților în sistemul hotelier. Acestea includ:         *
 *    - Obținerea tuturor angajaților (GetAll)                           *
 *    - Adăugarea unui nou angajat (Add)                                  *
 *    - Eliminarea unui angajat existent (Remove)                         *
 *  Interfața servește ca contract pentru implementările concrete ale     *
 *  repository-ului, asigurând abstractizarea accesului la date.          *
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

namespace HotelBook.Data
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        void Add(Employee emp);
        void Remove(int id);
    }
}