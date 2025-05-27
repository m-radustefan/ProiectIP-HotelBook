/**************************************************************************
 *                                                                        *
 *  File:        Employee.cs                                              *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Clasă ce reprezintă un angajat în sistemul hotelier.     *
 *  Conține toate informațiile necesare gestionării angajaților:          *
 *    - Identificator unic                                                *
 *    - Nume și prenume                                                  *
 *    - Credențiale de autentificare (username și parolă)                 *
 *    - Rol în sistem (momentan doar Admin)                               *
 *  Clasa este sealed pentru a preveni moștenirea nedorită.              *
 *  Rolul este setat implicit la Admin pentru cerințele curente.          *
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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBook.Domain
{
    // Clasa defineste un angajat in sistemul hotelier.
    // Este sealed pentru a preveni mostenirea nedorita
    public sealed class Employee
    {        
        // Identificator unic al angajatului
        public int Id { get; set; }

        // Prenumele angajatului
        public string FirstName { get; set; }

        // Numele de familie al angajatului
        public string LastName { get; set; }

        // Numele de utilizator pentru autentificare
        public string Username { get; set; }

        // Parola asociata contului angajatului
        public string Password { get; set; }

        // Rolul angajatului in sistem (implicit Admin)
        public Role Role { get; set; } = Role.Admin;   
    }
}
