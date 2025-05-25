/**************************************************************************
 *                                                                        *
 *  File:        SessionManager.cs                                        *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Manager de sesiune pentru aplicația de gestionare hotel. *
 *  Păstrează starea autentificării utilizatorului curent și oferă:       *
 *    - Funcționalitate de login/logout                                   *
 *    - Verificare stare autentificare                                    *
 *    - Acces la utilizatorul curent                                      *
 *  Clasa este statică și thread-safe pentru utilizare simplificată.      *
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

namespace HotelBook.Services
{
    public static class SessionManager
    {
        public static User CurrentUser { get; private set; }

        public static void Login(User user)
        {
            CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
        }

        public static void Logout() => CurrentUser = null;

        public static bool IsLoggedIn => CurrentUser != null;
    }
}