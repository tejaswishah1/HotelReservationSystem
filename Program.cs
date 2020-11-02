using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hotel reservation system");

            HotelReservation hotelreservation = new HotelReservation();
            hotelreservation.AddHotel(new Hotel("Lakewood", 110, 90, 3));
            hotelreservation.AddHotel(new Hotel("Bridgewood", 150,50,4));
            hotelreservation.AddHotel(new Hotel("Ridgewood", 220, 150, 5));
        }
    }
}
