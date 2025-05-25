/**************************************************************************
 *                                                                        *
 *  File:        Room.cs                                                  *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Clasă ce reprezintă o cameră de hotel în sistem.          *
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
    public sealed class Room
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public RoomStatus Status { get; set; }
        public double Price { get; set; }    // ← nou
    }
}

