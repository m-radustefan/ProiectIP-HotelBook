/**************************************************************************
 *                                                                        *
 *  File:        IReservationRepository.cs                                *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Interfață care definește operațiunile de bază pentru     *
 *  gestionarea rezervărilor în sistemul hotelier. Acestea includ:        *
 *    - Obținerea tuturor rezervărilor (GetAll)                          *
 *    - Adăugarea unei noi rezervări (Add)                               *
 *    - Eliminarea rezervărilor după ID-ul camerei (RemoveByRoom)        *
 *  Interfața servește ca contract pentru implementările concrete ale     *
 *  repository-ului, asigurând abstractizarea accesului la date și       *
 *  separarea preocupărilor în arhitectura aplicației.                    *
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
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        void Add(Reservation r);
        void RemoveByRoom(int roomId);
    }
}
