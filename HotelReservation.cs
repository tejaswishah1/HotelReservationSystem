namespace HotelReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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
            try
            {
                foreach (var hotel in this.Hotels)
                {
                    Console.WriteLine("Hotel Name: {0} and Rate: {1}", hotel.hotelName, hotel.regularRate);
                }
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.INVALID_NAME, "Name should start with capital and contain at least 3 characters");
            }
        }

        /// <summary>
        /// Validate Date:
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime ValidateDate(string date)
        {
            DateTime dateStart = new DateTime(2016, 12, 23); ////23rd December 2016
            DateTime dateEnd = new DateTime(2020, 11, 04); ////4th November 2020

            try
            {
                DateTime dateForRecords = DateTime.Parse(date); ////Current Date in YYYY/MM/DD format
                if (dateForRecords < dateStart)
                {
                    throw new CustomException(CustomException.ExceptionType.DATE_BEFORE_RECORDS, "Enter date after 23rd December,2016");
                }

                if (dateForRecords > dateEnd)
                {
                    throw new CustomException(CustomException.ExceptionType.DATE_AFTER_RECORDS, "Enter date bedore 4th Nov 2020");
                }

                return dateForRecords;
            }
            catch
            {
                Console.WriteLine("Enter valid date");
                return this.ValidateDate(Console.ReadLine());
            }
        }

        /// <summary>
        /// Cheapest available hotel.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public Hotel FindCheapestHotelForGivenTime(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate.Subtract(startDate); ////End date- start date = Days stayed in hotel.
            double numberOfDaysStayed = timeSpan.TotalDays;  ////Inbuilt function
            Hotel cheapestAvailableHotel = Hotels[0]; ////Cheapest Hotel Available

            ////Calculation of total bill:
            double totalBill = numberOfDaysStayed * cheapestAvailableHotel.regularRate;

            foreach (Hotel hotels in Hotels)
            {
                if (hotels.regularRate < cheapestAvailableHotel.regularRate)
                {
                    cheapestAvailableHotel = hotels;
                }
            }
            Console.WriteLine("Cheapest hotel available" + cheapestAvailableHotel.hotelName);
            Console.WriteLine("Cheapest price available at: " + totalBill);
            return cheapestAvailableHotel;
        }
    }
}
