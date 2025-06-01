/**************************************************************************
 *                                                                        *
 *  File:        User.cs                                                  *
 *  Copyright:   (c) 2025, Bardasu Alexandru Ioan                         *
 *  E-mail:      alexandru-ioan.bardasu@student.tuiasi.ro                 *
 *  Description: Clasă ce reprezintă un utilizator în sistemul hotelier.  *
 *  Stochează informațiile esențiale ale utilizatorului:                  *
 *    - Numele de utilizator (username)                                   *
 *    - Rolul în sistem (Admin, Cleaner, Receptionist)                    *
 *  Clasa este sealed pentru a preveni moștenirea nedorită și             *
 *  oferă imutabilitate prin proprietăți read-only.                       *
 *  Constructorul validează username-ul pentru a preveni valori nule.     *
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


namespace HotelBook.Domain
{
    // Clasă ce reprezintă un utilizator al aplicației și rolul acestuia

    public sealed class User
    {
        public string Username { get; }
        public Role Role { get; }

        public User(string username, Role role)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Role = role;
        }
    }
}