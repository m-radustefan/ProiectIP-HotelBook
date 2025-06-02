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
using HotelBook.Services;
using HotelBook.Data;

namespace HotelBook.Tests
{
    [TestClass]
    public class HotelBookUnitTests
    {
        private string _dbFilePath;

        /// <summary>
        /// [TestInitialize]
        /// • Creează un .db temporar în folderul de Temp
        /// • Instanțiază SqliteEmployeeRepository, SqliteRoomRepository, SqliteReservationRepository
        /// • Injectează fiecare în câmpul privat static “_repo” al serviciilor statice, prin reflecție
        /// • Adaugă o cameră “Single” în baza SQLite seed
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // 1) Cream fișierul SQLite temporar
            _dbFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".db");

            // 2) Construim instanțele concrete de repository
            var empRepo = new SqliteEmployeeRepository(_dbFilePath);
            var roomRepo = new SqliteRoomRepository(_dbFilePath);
            var resRepo = new SqliteReservationRepository(_dbFilePath);

            // 3) Injectăm prin reflecție în EmployeeService, RoomService și ReservationService
            typeof(EmployeeService)
                .GetField("_repo", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, empRepo);

            typeof(RoomService)
                .GetField("_repo", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, roomRepo);

            typeof(ReservationService)
                .GetField("_repo", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, resRepo);

            // 4) Seed: adăugăm o cameră “Single”
            var seedRoom = new Room
            {
                Type = "Single",
                Price = 100.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(seedRoom);
        }

        /// <summary>
        /// [TestCleanup]
        /// Șterge fișierul temporar .db
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                if (File.Exists(_dbFilePath))
                    File.Delete(_dbFilePath);
            }
            catch
            {
                // ignorăm eroarea la ștergere
            }
        }


        // ==========================================================
        // 1) TESTE pentru EmployeeService (6 teste)
        // ==========================================================

        /// <summary>
        /// [Test 1] Initial: GetAll() returnează 0 angajați
        /// </summary>
        [TestMethod]
        public void EmployeeService_GetAll_InitiallyEmpty_ReturnsZero()
        {
            var all = EmployeeService.GetAll();
            Assert.IsNotNull(all, "GetAll() nu trebuie să returneze null.");
            Assert.AreEqual(0, all.Count(), "La început, lista de angajați trebuie să fie goală.");
        }

        /// <summary>
        /// [Test 2] Adăugare angajat valid → GetAll() returnează 1 și câmpurile sunt corecte
        /// </summary>
        [TestMethod]
        public void EmployeeService_AddAndGetAll_ReturnsInsertedEmployee()
        {
            // Confirmăm că nu există angajați inițial
            Assert.AreEqual(0, EmployeeService.GetAll().Count(), "Înainte de Add, count=0.");

            // Adăugăm un angajat valid
            var emp = new Employee
            {
                FirstName = "Ana",
                LastName = "Ionescu",
                Username = "anai",
                Password = "pass123",
                Role = Role.Admin
            };
            EmployeeService.Add(emp);

            // Verificăm că a fost adăugat
            var allAfterAdd = EmployeeService.GetAll().ToList();
            Assert.AreEqual(1, allAfterAdd.Count, "După Add, count=1.");
            Assert.AreEqual("anai", allAfterAdd[0].Username, "Username inserat incorect.");
            Assert.AreEqual("Ionescu", allAfterAdd[0].LastName, "LastName inserat incorect.");
            Assert.AreEqual(Role.Admin, allAfterAdd[0].Role, "Role inserat incorect.");

            // Ștergem angajatul
            var idToRemove = allAfterAdd[0].Id;
            EmployeeService.Remove(idToRemove);

            // Verificăm că s-a șters
            var allAfterRemove = EmployeeService.GetAll().ToList();
            Assert.AreEqual(0, allAfterRemove.Count, "După Remove, count=0.");
        }

        /// <summary>
        /// [Test 3] Add cu Username gol → ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmployeeService_AddWithEmptyUsername_ThrowsArgumentException()
        {
            var e = new Employee
            {
                FirstName = "Mihai",
                LastName = "Ionescu",
                Username = "",            // invalid
                Password = "passxx",
                Role = Role.Cleaner
            };
            EmployeeService.Add(e);
        }

        /// <summary>
        /// [Test 4] Add cu Username duplicat → InvalidOperationException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmployeeService_AddDuplicateUsername_ThrowsInvalidOperationException()
        {
            var e1 = new Employee
            {
                FirstName = "X",
                LastName = "Y",
                Username = "dupuser",
                Password = "aaa",
                Role = Role.Admin
            };
            var e2 = new Employee
            {
                FirstName = "Z",
                LastName = "W",
                Username = "dupuser",      // același username
                Password = "bbb",
                Role = Role.Cleaner
            };

            EmployeeService.Add(e1);
            EmployeeService.Add(e2);       // ar trebui să arunce InvalidOperationException
        }

        /// <summary>
        /// [Test 5] Remove cu ID inexistent → Exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EmployeeService_RemoveNonExisting_ThrowsException()
        {
            EmployeeService.Remove(999);   // nu există angajat cu id=999
        }

        /// <summary>
        /// [Test 6] Remove cu ID existent → lista devine goală
        /// </summary>
        [TestMethod]
        public void EmployeeService_RemoveExisting_RemovesSuccessfully()
        {
            var e = new Employee
            {
                FirstName = "George",
                LastName = "Popescu",
                Username = "gpop",
                Password = "pass",
                Role = Role.Receptionist
            };
            EmployeeService.Add(e);

            var allBefore = EmployeeService.GetAll().ToList();
            Assert.AreEqual(1, allBefore.Count, "Înainte de Remove, count=1.");

            EmployeeService.Remove(allBefore[0].Id);

            var allAfter = EmployeeService.GetAll().ToList();
            Assert.AreEqual(0, allAfter.Count, "După Remove, count=0.");
        }


        // ==========================================================
        // 2) TESTE pentru RoomService (6 teste)
        // ==========================================================

        /// <summary>
        /// [Test 7] GetAll inițial → 1 cameră (cea “Single” semănțată în TestInitialize)
        /// </summary>
        [TestMethod]
        public void RoomService_GetAll_InitiallyOne_ReturnsOne()
        {
            var all = RoomService.GetAll().ToList();
            Assert.AreEqual(1, all.Count, $"Inițial ar trebui o singură cameră în db, ai: {all.Count}.");
            Assert.AreEqual("Single", all[0].Type, "Tipul camerei seed nu e „Single”.");
            Assert.AreEqual(100.0, all[0].Price, "Prețul camerei seed nu e 100.0.");
            Assert.AreEqual(RoomStatus.ReadyToBook, all[0].Status, "Status-ul camerei seed nu e ReadyToBook.");
        }

        /// <summary>
        /// [Test 8] Add cameră validă → count crește la 2 și câmpurile sunt corecte
        /// </summary>
        [TestMethod]
        public void RoomService_AddValidRoom_ReturnsInsertedRoom()
        {
            // Confirmăm că la început e exact 1 cameră
            Assert.AreEqual(1, RoomService.GetAll().Count(), "Înainte de Add, count=1 seed.");

            // Adăugăm o nouă cameră “Double”
            var room = new Room
            {
                Type = "Double",
                Price = 150.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(room);

            // Verificăm că avem 2 camere
            var allAfterAdd = RoomService.GetAll().ToList();
            Assert.AreEqual(2, allAfterAdd.Count, "După Add, count trebuia să fie 2.");

            var found = allAfterAdd.SingleOrDefault(r => r.Type == "Double");
            Assert.IsNotNull(found, "Camera 'Double' nu a fost găsită.");
            Assert.AreEqual(150.0, found.Price, "Prețul camerei 'Double' nu a fost salvat corect.");
            Assert.AreEqual(RoomStatus.ReadyToBook, found.Status, "Status-ul camerei 'Double' nu a fost salvat corect.");
        }

        /// <summary>
        /// [Test 9] Add cu Type gol → ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoomService_AddEmptyType_ThrowsArgumentException()
        {
            var r = new Room
            {
                Type = "",                   // invalid
                Price = 30.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(r);
        }

        /// <summary>
        /// [Test 10] Add cu Price negativ → ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoomService_AddNegativePrice_ThrowsArgumentException()
        {
            var r = new Room
            {
                Type = "Family",
                Price = -50.0,               // invalid
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(r);
        }

        /// <summary>
        /// [Test 11] Remove cu ID inexistent → Exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RoomService_RemoveNonExisting_ThrowsException()
        {
            RoomService.Remove(999);      // nu există cameră cu id=999
        }

        /// <summary>
        /// [Test 12] Remove cu ID existent → count scade la 0
        /// </summary>
        [TestMethod]
        public void RoomService_RemoveExisting_RemovesSuccessfully()
        {
            var allBefore = RoomService.GetAll().ToList();
            Assert.AreEqual(1, allBefore.Count, "Înainte de Remove, count=1 seed.");

            RoomService.Remove(allBefore[0].Id);

            var allAfter = RoomService.GetAll().ToList();
            Assert.AreEqual(0, allAfter.Count, "După Remove, count=0.");
        }


        // ==========================================================
        // 3) TESTE pentru ReservationService (5 teste + 1 addMultiple)
        // ==========================================================

        /// <summary>
        /// [Test 13] GetAll inițial → 0 rezervări
        /// </summary>
        [TestMethod]
        public void ReservationService_GetAll_InitiallyEmpty_ReturnsZero()
        {
            var all = ReservationService.GetAll();
            Assert.IsNotNull(all, "GetAll rezervări nu trebuie să returneze null.");
            Assert.AreEqual(0, all.Count(), "Inițial, nu există nicio rezervare.");
        }

        /// <summary>
        /// [Test 14] Add rezervare validă → GetAll returnează 1 rezervare cu câmpurile corecte
        /// </summary>
        [TestMethod]
        public void ReservationService_AddAndGetAll_ReturnsInsertedReservation()
        {
            // 1) Adăugăm o cameră “Suite” ca să avem un RoomId valid
            var room = new Room
            {
                Type = "Suite",
                Price = 200.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(room);
            var insertedRoom = RoomService.GetAll().Single(r => r.Type == "Suite");

            // 2) Construim rezervarea
            var reservation = new Reservation
            {
                RoomId = insertedRoom.Id,
                RoomType = insertedRoom.Type,    // câmp NOT NULL
                Nights = 3,
                FirstName = "Ion",
                LastName = "Popescu",
                Phone = "0722111222",
                Email = "ion.popescu@example.com"
            };
            ReservationService.Add(reservation);

            // 3) Verificăm că a apărut exact o rezervare
            var allAfterAdd = ReservationService.GetAll().ToList();
            Assert.AreEqual(1, allAfterAdd.Count, "După Add, count rezervări=1.");

            var rFound = allAfterAdd[0];
            Assert.AreEqual(insertedRoom.Id, rFound.RoomId, "RoomId nu a fost salvat corect.");
            Assert.AreEqual("Popescu", rFound.LastName, "LastName nu a fost salvat corect.");
            Assert.AreEqual(3, rFound.Nights, "Nights nu a fost salvat corect.");
            Assert.AreEqual("Suite", rFound.RoomType, "RoomType nu a fost salvat corect.");
        }

        /// <summary>
        /// [Test 15] Add cu RoomId invalid (0) → ArgumentException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReservationService_AddWithInvalidRoom_ThrowsArgumentException()
        {
            var r = new Reservation
            {
                RoomId = 0,                  // invalid
                RoomType = "Whatever",
                Nights = 2,
                FirstName = "Ana",
                LastName = "Mihai",
                Phone = "0722333444",
                Email = "ana@example.com"
            };
            ReservationService.Add(r);
        }

        /// <summary>
        /// [Test 16] RemoveByRoom cu ID inexistent → Exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReservationService_RemoveByRoom_NonExisting_ThrowsException()
        {
            ReservationService.RemoveByRoom(999);    // nu există rezervare cu RoomId=999
        }

        /// <summary>
        /// [Test 17] RemoveByRoom cu ID existent → rezervarea dispare
        /// </summary>
        [TestMethod]
        public void ReservationService_RemoveByRoom_Existing_RemovesSuccessfully()
        {
            // Adăugăm o cameră “King” și o rezervare pe ea
            var room = new Room
            {
                Type = "King",
                Price = 180.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(room);
            var rCam = RoomService.GetAll().Single(rm => rm.Type == "King");

            var rez = new Reservation
            {
                RoomId = rCam.Id,
                RoomType = rCam.Type,
                Nights = 1,
                FirstName = "George",
                LastName = "Lazar",
                Phone = "0733555777",
                Email = "george.lazar@example.com"
            };
            ReservationService.Add(rez);

            // Verificăm că există o rezervare
            Assert.AreEqual(1, ReservationService.GetAll().Count(), "Count Before = 1.");

            // Ștergem după RoomId
            ReservationService.RemoveByRoom(rCam.Id);

            // Verificăm că a dispărut
            Assert.AreEqual(0, ReservationService.GetAll().Count(), "Count After = 0.");
        }

        /// <summary>
        /// [Test 18] Adăugăm mai multe rezervări pe camere diferite → Count corespunzător
        /// </summary>
        [TestMethod]
        public void ReservationService_AddMultiple_ReturnsCorrectCount()
        {
            // Adăugăm două camere
            var roomA = new Room
            {
                Type = "Twin",
                Price = 90.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(roomA);
            var roomB = new Room
            {
                Type = "Family",
                Price = 120.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(roomB);

            // Obținem ID-urile lor
            var rA = RoomService.GetAll().Single(r => r.Type == "Twin");
            var rB = RoomService.GetAll().Single(r => r.Type == "Family");

            // Adăugăm două rezervări
            var rez1 = new Reservation
            {
                RoomId = rA.Id,
                RoomType = rA.Type,
                Nights = 2,
                FirstName = "Alice",
                LastName = "Roman",
                Phone = "0722111000",
                Email = "alice.roman@example.com"
            };
            var rez2 = new Reservation
            {
                RoomId = rB.Id,
                RoomType = rB.Type,
                Nights = 1,
                FirstName = "Bogdan",
                LastName = "Stanciu",
                Phone = "0722222333",
                Email = "bogdan.stanciu@example.com"
            };
            ReservationService.Add(rez1);
            ReservationService.Add(rez2);

            // Verificăm că avem 2 rezervări
            Assert.AreEqual(2, ReservationService.GetAll().Count(), "După două Add, count trebuie să fie 2.");
        }


        // ==========================================================
        // 4) TESTE „BookingFlow” (2 teste)
        // ==========================================================

        /// <summary>
        /// [Test 19] BookingFlow fără update de status → status rămâne ReadyToBook
        /// </summary>
        [TestMethod]
        public void BookingFlow_BackFromBooking_NoStatusChange()
        {
            // 1) Adăugăm o cameră nouă “Premium”
            var room = new Room
            {
                Type = "Premium",
                Price = 250.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(room);
            var inserted = RoomService.GetAll().First(r => r.Type == "Premium");
            Assert.AreEqual(RoomStatus.ReadyToBook, inserted.Status, "Inițial status=ReadyToBook.");

            // 2) Adăugăm o rezervare pe camera “Premium”
            var rez = new Reservation
            {
                RoomId = inserted.Id,
                RoomType = inserted.Type,
                Nights = 2,
                FirstName = "Andrei",
                LastName = "Dumitru",
                Phone = "0722999111",
                Email = "andrei.d@example.com"
            };
            ReservationService.Add(rez);

            // 3) Fără să update‐m statusul, validăm că în db rămâne ReadyToBook
            var afterReservation = RoomService.GetAll().First(r => r.Id == inserted.Id);
            Assert.AreEqual(RoomStatus.ReadyToBook, afterReservation.Status,
                "După Add rezervare, fără a apela RoomService.Update, status trebuie să rămână ReadyToBook.");
        }

        /// <summary>
        /// [Test 20] BookingFlow complet: adăugăm rezervarea, apoi setăm status = Booked și apelăm Update → verificăm în db
        /// </summary>
        [TestMethod]
        public void BookingFlow_AfterReservation_StatusChangedToBooked()
        {
            // 1) Adăugăm camera “Deluxe”
            var room = new Room
            {
                Type = "Deluxe",
                Price = 300.0,
                Status = RoomStatus.ReadyToBook
            };
            RoomService.Add(room);
            var inserted = RoomService.GetAll().First(r => r.Type == "Deluxe");
            Assert.AreEqual(RoomStatus.ReadyToBook, inserted.Status, "Inițial, status=ReadyToBook.");

            // 2) Adăugăm rezervarea
            var rez = new Reservation
            {
                RoomId = inserted.Id,
                RoomType = inserted.Type,
                Nights = 1,
                FirstName = "Maria",
                LastName = "Voicu",
                Phone = "0723555123",
                Email = "maria.voicu@example.com"
            };
            ReservationService.Add(rez);

            // 3) Modificăm status în cod și apelăm Update
            inserted.Status = RoomStatus.Booked;
            RoomService.Update(inserted);

            // 4) Verificăm în baza SQLite că status chiar s-a schimbat
            var updated = RoomService.GetAll().First(r => r.Id == inserted.Id);
            Assert.AreEqual(RoomStatus.Booked, updated.Status, "Status ar fi trebuit să devină Booked.");

            // 5) Verificăm că rezervarea există
            var allRes = ReservationService.GetAll().ToList();
            Assert.AreEqual(1, allRes.Count, "După Add rezervare, count=1.");
            Assert.AreEqual("Voicu", allRes[0].LastName, "LastName client rezervare incorect.");
        }
    }
}

