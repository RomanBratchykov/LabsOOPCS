using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_cs_
{
    internal class VetClinic
    {
        Animal[]? rooms;
        public string Name { get; set; }
        public VetClinic(int numberOfRooms, string name)
        {
            if (numberOfRooms <= 0)
            {
                throw new ArgumentException("Number of rooms must be greater than zero.");
            }
            if (numberOfRooms % 2 == 0)
            {
                throw new ArgumentException("Number of room should be odd");
            }
            rooms = new Animal[numberOfRooms];
            Name = name;
        }
        public bool AddAnimal(Animal animal)
        {
            int center = rooms.Length / 2;
            for (int offset = 0; offset <= center; offset++)
            {
                int right = center + offset;
                if (right < rooms.Length && rooms[right] == null)
                {
                    rooms[right] = animal;
                    return true;
                }
                int left = center - offset;
                if (left >= 0 && rooms[left] == null)
                {
                    rooms[left] = animal ;
                    return true;
                }
            }
            return false;
        }
        public bool Release()
        {
            int center = rooms.Length / 2;
            for (int i = center; i < rooms.Length; i++)
            {
                if (rooms[i] != null)
                {
                    rooms[i] = null;
                    return true;
                }
            }
            for (int i = 0; i < center; i++)
            {
                if (rooms[i] != null)
                {
                    rooms[i] = null;
                    return true;
                }
            }
            return false;
        }
        public bool HasEmptyRooms()
        {
            return rooms.All(r => r == null);
        }
        public void PrintRoom(int roomNumber)
        {
            if (roomNumber < 1 || roomNumber > rooms.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid room number.");
            }
            var room = rooms[roomNumber - 1];
            if (room != null)
            {
                room.PrintInfo();
            }
            else
            {
                Console.WriteLine("Room is empty.");
            }
        }
        public void PrintRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i] != null)
                {
                    Console.WriteLine($"Room {i + 1}:");
                    rooms[i].PrintInfo();
                }
                else
                {
                    Console.WriteLine($"Room {i + 1}: Empty");
                }
            }
        }
    }
}