namespace HotelReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
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
        /// Declaring cheapest rate for hotel fare.
        /// </summary>
        public static double cheapestRate = 0;

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
                    Console.WriteLine("Hotel Name: {0} and Weekday Rate and {1} and Weekend Rate", hotel.hotelName,
                        hotel.weekdayRegularRate, hotel.weekendRegularRate);
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
        public List<Hotel> FindCheapestHotelForGivenTime(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate.Subtract(startDate); ////End date- start date = Days stayed in hotel.
            int numberOfDaysStayed = (int)timeSpan.TotalDays;  ////Inbuilt function
            int weekDays = GetWeekdaysDuringStay(startDate, endDate);   ////Weekdays
            int weekEnds = numberOfDaysStayed - weekDays; ////Total - weekdays
            cheapestRate = CheapestHotel(weekDays, weekEnds);
            var cheapestAvailableHotel = Hotels.Where(Hotel => (weekDays * Hotel.weekdayRegularRate) +
             (weekEnds * Hotel.weekendRegularRate) == cheapestRate).ToList();
            return cheapestAvailableHotel;


        }

        public double CheapestHotel(int weekDays, int weekEnds)
        {
            double cheapestHotel = Hotels.Min(Hotel => (weekDays * Hotel.weekdayRegularRate) + (weekEnds * Hotel.weekendRegularRate));
            return cheapestHotel;
           
        }

        /// <summary>
        /// Check weekdays. Then subtract from total days to get weekends.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public int GetWeekdaysDuringStay(DateTime startDate, DateTime endDate)
        {
            int numberOfDays = 0;
            ////Start date canot be after end date.
            try
            {
                if (startDate >= endDate)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_DATE, "Start date cannot be after end date");
                }
            }
            catch
            {
                while (startDate <= endDate)
                {
                    ////Checking start days is Weekend or not
                    if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        ++numberOfDays;
                    }

                    startDate = startDate.AddDays(1);
                }
            }

            return numberOfDays;
        }
        /// <summary>
        /// Cheapest best rated Hotel
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<Hotel> FindCheapestBestRatedHotel(DateTime start, DateTime end)
        {
            List<Hotel> cheapestHotels = FindCheapestHotelForGivenTime(start,end);
            int maxRating = cheapestHotels.Max(hotel => hotel.hotelRating);
            return cheapestHotels.FindAll(hotel => hotel.hotelRating == maxRating);
        }
        
        public void DisplayCheapestBestRatedHotel(List<Hotel> cheapestHotel)
        {
            foreach (Hotel hotel in cheapestHotel)
            {
                Console.WriteLine("Hotel name: " + hotel.hotelName + "Total bill :" + cheapestRate);
            }
        }





    }
}