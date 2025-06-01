/**************************************************************************
 *                                                                        *
 *  File:        Reservation.cs                                           *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-ionut.padurariu@student.tuiasi.ro                  *
 *  Description: Clasă ce reprezintă o rezervare în sistemul hotelier.    *
 *  Stochează toate informațiile necesare unei rezervări:                 *
 *    - Identificator unic și ID cameră                                   *
 *    - Tipul camerei și număr de nopți                                   *
 *    - Datele de contact ale clientului (nume, telefon, email)           *
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

namespace HotelBook.Domain
{
    public sealed class Reservation
    {
        // ID unic al rezervării
        public int Id { get; set; }

        // ID-ul camerei rezervate
        public int RoomId { get; set; }

        // Tipul camerei rezervate (ex: single, double)
        public string RoomType { get; set; }

        // Numărul de nopți rezervate
        public int Nights { get; set; }
        
        // Prenumele clientului
        public string FirstName { get; set; }

        // Numele clientului
        public string LastName { get; set; }

        // Telefonul clientului
        public string Phone { get; set; }

        // Email-ul clientului
        public string Email { get; set; }
    }
}
