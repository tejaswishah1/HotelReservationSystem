
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
        public int regularRate;

    /// <summary>
    /// Parametrised Constructor
    /// </summary>
    /// <param name="hotelName"></param>
    /// <param name="regularRate"></param>
        public Hotel(string hotelName, int regularRate)
        {
            this.hotelName = hotelName;
            this.regularRate = regularRate;
        }
    }
}

