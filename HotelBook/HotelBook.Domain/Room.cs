/**************************************************************************
 *                                                                        *
 *  File:        Room.cs                                                  *
 *  Copyright:   (c) 2025, Bardasu Alexandru Ioan                         *
 *  E-mail:      alexandru-ioan.bardasu@student.tuiasi.ro                 *
 *  Description: Clasă ce reprezintă o cameră de hotel în sistem.         *
 *  Conține toate informațiile necesare gestionării camerelor:            *
 *    - Identificator unic                                                *
 *    - Tipul camerei (Single, Double, Suite etc.)                        *
 *    - Starea curentă (disponibilă, ocupată, în mentenanță etc.)         *
 *    - Prețul pe noapte                                                  *
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
    // Clasă ce modelează o cameră de hotel cu proprietăți esențiale pentru management
    public sealed class Room
    {
        // Identificator unic al camerei
        public int Id { get; set; }

        // Tipul camerei (ex: Single, Double, Suite)
        public string Type { get; set; }

        // Starea curentă a camerei (ex: Disponibilă, Ocupată)
        public RoomStatus Status { get; set; }

        // Prețul pe noapte în monedă locală
        public double Price { get; set; }   
    }
}

