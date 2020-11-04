
namespace HotelReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// Hotel class created to add Data regarding hotels.
    /// </summary>
    public class Hotel
    {
        /// <summary>
        /// Name of hotel. Should start with a capital letter and have Minimum 3 characters.
        /// </summary>
        public string hotelName = "^[A-Z][a-z][0-9]{3,}?";

        /// <summary>
        /// Regular rate for hotel.
        /// </summary>
        //public int regularRate;

        /// <summary>
        /// Weekday regular rate
        /// </summary>
        public int weekdayRegularRate;

        /// <summary>
        /// Weekend Regular rate:
        /// </summary>
        public int weekendRegularRate;

        /// <summary>
        /// Hotel Rating
        /// </summary>
        public int hotelRating;
        /// <summary>
        /// Parametrised Constructor
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="regularRate"></param>
        public Hotel(string hotelName, int weekdayRegularRate, int weekendRegularRate, int hotelRating)
        {
            this.hotelName = hotelName;
            //this.regularRate = regularRate;
            this.weekdayRegularRate = weekdayRegularRate;
            this.weekendRegularRate = weekendRegularRate;
            this.hotelRating = hotelRating;
        }

      
    }
}

