/**************************************************************************
 *                                                                        *
 *  File:        IRoomRepository.cs                                       *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-iontu.padurariu@student.tuiasi.ro                  *
 *  Description: Interfață care definește operațiunile CRUD pentru        *
 *  gestionarea camerelor hotelului în sistem. Acestea includ:            *
 *    - Obținerea tuturor camerelor (GetAll)                             *
 *    - Actualizarea informațiilor unei camere (Update)                  *
 *    - Adăugarea unei camere noi (Add)                                  *
 *    - Eliminarea unei camere după ID (Remove)                          *
 *  Interfața asigură abstractizarea accesului la date și separarea      *
 *  logicii de business de mecanismele de stocare persistentă.           *
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
    // Interfata care defineste operatiile CRUD pentru gestionarea camerelor hotelului.
    // Asigura abstractizarea accesului la date si separarea logicii de business de stocarea persistenta.
    public interface IRoomRepository
    {
        // Returneaza toate camerele existente.
        IEnumerable<Room> GetAll();

        // Actualizeaza informatiile unei camere existente.
        void Update(Room room);

        // Adauga o camera noua.
        void Add(Room room);

        // Elimina o camera pe baza ID-ului.
        void Remove(int id);

    }
}
