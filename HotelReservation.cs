namespace HotelReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Created HotelReservation class to add and view Hotels in Miami
    /// </summary>
    public class HotelReservation
    {
        /// <summary>
        /// List to store details of hotels
        /// </summary>
        public List<Hotel> Hotels = new List<Hotel>();

        /// <summary>
        /// Add details of hotel:
        /// </summary>
        /// <param name="newHotelAdd"></param>
        public void AddHotel(Hotel newHotelAdd)
        {
            this.Hotels.Add(newHotelAdd);
        }

        /// <summary>
        /// Display the hotel names and their rates
        /// </summary>
        public void DisplayHotels()
        {
            Console.WriteLine("Welcome to our hotels in Miami \n");
            foreach (var hotel in this.Hotels)
            {
                Console.WriteLine("Hotel Name: {0} and Rate: {1}", hotel.hotelName, hotel.regularRate);
            }
        }
    }
}
