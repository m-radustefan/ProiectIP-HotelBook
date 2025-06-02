/**************************************************************************
 *                                                                        *
 *  File:        RoomService.cs                                           *
 *  Copyright:   (c) 2025, Padurariu Matei Ionut                          *
 *  E-mail:      matei-ionut.padurariu@student.tuiasi.ro                  *
 *  Description: Serviciu static pentru gestionarea camerelor hotelului.  *
 *  Utilizează același fișier SQLite ca EmployeeService dar cu tabelă     *
 *  separată pentru camere. Oferă funcționalități complete CRUD:          *
 *    - Obținerea tuturor camerelor                                       *
 *    - Actualizarea informațiilor despre o cameră                        *
 *    - Adăugarea unei camere noi                                         *
 *    - Ștergerea unei camere după ID                                     *
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
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBook.Domain;
using HotelBook.Data;
using HotelBook.Services;

namespace HotelBook.Tests
{
    [TestClass]
    public class HotelBookUnitTests
    {
        private string _dbFilePath;

        [TestInitialize]
        public void TestInitialize()
        {
            // Creăm un fișier temporar pentru baza SQLite
            _dbFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".db");

            // Forțăm serviciile să folosească repo‐urile care pun datele în fișierul temporar
            var empRepo = new SqliteEmployeeRepository(_dbFilePath);
            typeof(EmployeeService)
                .GetField("_repo", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, empRepo);

            var roomRepo = new SqliteRoomRepository(_dbFilePath);
            typeof(RoomService)
                .GetField("_repo", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, roomRepo);

            var resRepo = new SqliteReservationRepository(_dbFilePath);
            typeof(ReservationService)
                .GetField("_repo", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, resRepo);

            // Adăugăm o cameră “Single” în baza de date temporară
            var r = new Room
            {
                Type = "Single",
                Price = 100.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(r);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Ștergem fișierul temporar dacă există
            try
            {
                if (File.Exists(_dbFilePath))
                    File.Delete(_dbFilePath);
            }
            catch
            {
                // Ignorăm orice eroare la ștergere
            }
        }

        /// <summary>
        /// [Test 1] Adăugare angajat → EmployeeService.GetAll() returnează angajatul și câmpurile corecte.
        /// </summary>
        [TestMethod]
        public void EmployeeService_AddAndGetAll_ReturnsInsertedEmployee()
        {
            var initial = EmployeeService.GetAll();
            Assert.IsNotNull(initial);
            Assert.AreEqual(0, initial.Count(), "GetAll() inițial nu întoarce listă goală.");

            var emp = new Employee
            {
                FirstName = "Ana",
                LastName = "Ionescu",
                Username = "anai",
                Password = "pass123",
                Role = Role.Admin
            };
            EmployeeService.Add(emp);

            var allAfterAdd = EmployeeService.GetAll().ToList();
            Assert.AreEqual(1, allAfterAdd.Count, "După Add, trebuie exact un angajat.");
            Assert.AreEqual("anai", allAfterAdd[0].Username, "Username inserat incorect.");
            Assert.AreEqual("Ionescu", allAfterAdd[0].LastName, "LastName inserat incorect.");
            Assert.AreEqual(Role.Admin, allAfterAdd[0].Role, "Role inserat incorect.");

            int idToRemove = allAfterAdd[0].Id;
            EmployeeService.Remove(idToRemove);
            var afterRemove = EmployeeService.GetAll().ToList();
            Assert.AreEqual(0, afterRemove.Count, "După Remove, lista nu este goală.");
        }

        /// <summary>
        /// [Test 2] Adăugare cameră → RoomService.GetAll() returnează camera și câmpurile corecte.
        /// </summary>
        [TestMethod]
        public void RoomService_AddAndGetAll_ReturnsInsertedRoom()
        {
            var initial = RoomService.GetAll().ToList();
            Assert.AreEqual(1, initial.Count, $"Inițial ar trebui 1 cameră, găsit {initial.Count}.");

            var room = new Room
            {
                Type = "Double",
                Price = 150.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(room);

            var allAfterAdd = RoomService.GetAll().ToList();
            Assert.AreEqual(2, allAfterAdd.Count, "După Add, trebuie 2 camere.");

            var found = allAfterAdd.SingleOrDefault(r => r.Type == "Double");
            Assert.IsNotNull(found, "Camera 'Double' nu a fost găsită.");
            Assert.AreEqual(150.0, found.Price, "Prețul camerei nu a fost salvat corect.");
            Assert.AreEqual(RoomStatus.ReadyToBook, found.Status, "Status-ul camerei nu a fost salvat corect.");

            RoomService.Remove(found.Id);
            var afterRemove = RoomService.GetAll().ToList();
            Assert.AreEqual(1, afterRemove.Count, "După Remove, trebuie să rămână o singură cameră.");
        }

        /// <summary>
        /// [Test 3] Schimbare status cameră → RoomService.Update() modifică status-ul corect.
        /// </summary>
        [TestMethod]
        public void RoomService_UpdateStatus_ChangesRoomStatusInDb()
        {
            var room = RoomService.GetAll().First(r => r.Type == "Single");
            Assert.AreEqual(RoomStatus.ReadyToBook, room.Status, "Status inițial ar trebui ReadyToBook.");

            room.Status = RoomStatus.Booked;
            RoomService.Update(room);

            var updated = RoomService.GetAll().First(r => r.Id == room.Id);
            Assert.AreEqual(RoomStatus.Booked, updated.Status, "Status nu a fost actualizat la Booked.");
        }

        /// <summary>
        /// [Test 4] Adăugare rezervare → ReservationService.GetAll() returnează rezervarea și câmpurile corecte.
        /// </summary>
        [TestMethod]
        public void ReservationService_AddAndGetAll_ReturnsInsertedReservation()
        {
            var initial = ReservationService.GetAll();
            Assert.IsNotNull(initial);
            Assert.AreEqual(0, initial.Count(), "GetAll rezervări inițial nu întoarce listă goală.");

            var room = RoomService.GetAll().First(r => r.Type == "Single");
            var reservation = new Reservation
            {
                RoomId = room.Id,
                RoomType = room.Type,          // <— trebuie setat ca să nu încalce NOT NULL
                Nights = 3,
                FirstName = "Ion",
                LastName = "Popescu",
                Phone = "0722123456",
                Email = "ion.popescu@example.com"
            };
            ReservationService.Add(reservation);

            var allAfterAdd = ReservationService.GetAll().ToList();
            Assert.AreEqual(1, allAfterAdd.Count, "După Add, nu există exact o rezervare.");

            var rFound = allAfterAdd[0];
            Assert.AreEqual(room.Id, rFound.RoomId, "RoomId înregistrat incorect.");
            Assert.AreEqual("Single", rFound.RoomType, "RoomType nu a fost salvat corect.");
            Assert.AreEqual(3, rFound.Nights, "Numărul de nopți nu a fost salvat corect.");
            Assert.AreEqual("Popescu", rFound.LastName, "LastName client incorect.");

            // Dacă aţi adăugat RemoveByRoomId în ReservationService:
            ReservationService.RemoveByRoom(room.Id);

            var afterRemove = ReservationService.GetAll().ToList();
            Assert.AreEqual(0, afterRemove.Count, "După RemoveByRoomId, lista nu este goală.");
        }

        /// <summary>
        /// [Test 5] Flux complet rezervare + set status Booked → camera devine Booked după rezervare.
        /// </summary>
        [TestMethod]
        public void BookingFlow_AfterReservation_RoomStatusBecomesBooked()
        {
            var room = RoomService.GetAll().First(r => r.Type == "Single");
            room.Status = RoomStatus.ReadyToBook;
            RoomService.Update(room);

            var res = new Reservation
            {
                RoomId = room.Id,
                RoomType = room.Type,          // <— trebuie setat
                Nights = 2,
                FirstName = "Maria",
                LastName = "Ionescu",
                Phone = "0733001122",
                Email = "maria.ionescu@example.com"
            };
            ReservationService.Add(res);

            room.Status = RoomStatus.Booked;
            RoomService.Update(room);

            var updatedRoom = RoomService.GetAll().First(r => r.Id == room.Id);
            Assert.AreEqual(RoomStatus.Booked, updatedRoom.Status, "Camera nu a fost marcată Booked după rezervare.");

            var allRes = ReservationService.GetAll().ToList();
            Assert.AreEqual(1, allRes.Count, "Număr rezervări incorect după Add.");
            Assert.AreEqual("Ionescu", allRes[0].LastName, "Nume client rezervare incorect.");
        }
    }
}
