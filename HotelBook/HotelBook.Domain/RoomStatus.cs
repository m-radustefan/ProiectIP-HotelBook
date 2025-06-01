/**************************************************************************
 *                                                                        *
 *  File:        RoomStatus.cs                                            *
 *  Copyright:   (c) 2025, Rusu Eduard Ionut                              *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Enumerare care definește stările posibile ale unei camere*
 *  de hotel în sistemul de gestionare. Valorile disponibile sunt:        *
 *    - ReadyToBook: Cameră disponibilă pentru rezervare                  *
 *    - Booked: Cameră rezervată de un client                             *
 *    - CheckOut: Clientul a părăsit camera, necesită curățenie           *
 *  Utilizat pentru gestionarea fluxului camerelor în sistemul hotelier.  *
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
    // Enumerare ce definește stările posibile ale unei camere de hotel
    public enum RoomStatus
    {
        ReadyToBook,
        Booked,
        CheckOut
    }
}

