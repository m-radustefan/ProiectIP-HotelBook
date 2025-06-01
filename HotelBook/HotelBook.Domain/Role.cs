/**************************************************************************
 *                                                                        *
 *  File:        Role.cs                                                  *
 *  Copyright:   (c) 2025, Rusu Eduard Ionut                              *
 *  E-mail:      eduard-ionut.rusu@student.tuiasi.ro                      *
 *  Description: Enumerare care definește rolurile disponibile în sistemul*
 *  de gestionare hotelieră. Valorile posibile sunt:                      *
 *    - Admin: Drepturi complete de administrare                          *
 *    - Cleaner: Personal de curățenie                                    *
 *    - Receptionist: Personal de la recepție                             *
 *  Utilizat pentru controlul accesului și al drepturilor utilizatorilor. *
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
    // Enumerare ce definește rolurile utilizatorilor din sistem
    public enum Role { Admin, Cleaner, Receptionist }
}