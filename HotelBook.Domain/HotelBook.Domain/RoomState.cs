using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBook.Domain
{
    public enum RoomStatus { Ready, Booked, Occupied, Maintenance }

    public interface IRoomState
    {
        RoomStatus Status { get; }
        void Book(Room room);
        void CheckIn(Room room);
        void CheckOut(Room room);
        void SetReady(Room room);
    }

    public sealed class Room
    {
        public int Number { get; }
        public int Capacity { get; }

        private IRoomState _state;
        public RoomStatus Status => _state.Status;

        public Room(int number, int capacity)
        {
            Number = number;
            Capacity = capacity;
            _state = ReadyState.Instance;      // starea implicită
        }

        internal void Transition(IRoomState state) => _state = state;

        public void Book() => _state.Book(this);
        public void CheckIn() => _state.CheckIn(this);
        public void CheckOut() => _state.CheckOut(this);
        public void SetReady() => _state.SetReady(this);
    }

    // ---------- concrete States ----------
    sealed class ReadyState : IRoomState
    {
        private ReadyState() { }
        public static ReadyState Instance { get; } = new ReadyState();
        public RoomStatus Status => RoomStatus.Ready;

        public void Book(Room r) => r.Transition(BookedState.Instance);
        public void CheckIn(Room r) => throw new InvalidOperationException("Room must be booked first.");
        public void CheckOut(Room r) => throw new InvalidOperationException("Room is not occupied.");
        public void SetReady(Room r) { /*already ready*/ }
    }

    sealed class BookedState : IRoomState
    {
        private BookedState() { }
        public static BookedState Instance { get; } = new BookedState();
        public RoomStatus Status => RoomStatus.Booked;

        public void Book(Room r) => throw new InvalidOperationException("Room already booked.");
        public void CheckIn(Room r) => r.Transition(OccupiedState.Instance);
        public void CheckOut(Room r) => throw new InvalidOperationException("Room not occupied yet.");
        public void SetReady(Room r) => r.Transition(ReadyState.Instance);
    }

    sealed class OccupiedState : IRoomState
    {
        private OccupiedState() { }
        public static OccupiedState Instance { get; } = new OccupiedState();
        public RoomStatus Status => RoomStatus.Occupied;

        public void Book(Room r) => throw new InvalidOperationException("Room is occupied.");
        public void CheckIn(Room r) => throw new InvalidOperationException("Already checked-in.");
        public void CheckOut(Room r) => r.Transition(ReadyState.Instance);
        public void SetReady(Room r) => throw new InvalidOperationException("Check-out first.");
    }
}