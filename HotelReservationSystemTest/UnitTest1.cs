namespace HotelReservationSystemTest
{
    using HotelReservationSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// To check count of hotels in List:
        /// </summary>
        [TestMethod]
        public void GIVEN_DETAILS_OF_HOTEL_RETURN_COUNT_OF_HOTELS()
        {
            HotelReservation hotel = new HotelReservation();
            hotel.AddHotel(new Hotel("Lakewood", 110, 90,3));
            hotel.AddHotel(new Hotel("Bridgewood", 160, 60,4));
            hotel.AddHotel(new Hotel("Ridgewood", 220, 150,5));

            int expected = 3;
            int actual = hotel.Hotels.Count();

            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// To check cheapest hotel:
        /// </summary>
        [TestMethod]
        public void GIVEN_DETAILS_OF_HOTEL_RETURN_CHEAPEST_HOTEL_FOR_GIVEN_DATE()
        {
            string datestart = "10 Sep 2018";
            DateTime startDate = DateTime.Parse(datestart); ////StartDate
            string dateEnd = "17 Sep 2018";
            DateTime endDate = DateTime.Parse(dateEnd); ////End Date
            ////Create instance
            HotelReservation hotel = new HotelReservation();
            ////Add Hotels
            hotel.AddHotel(new Hotel("Lakewood", 110, 90,3));
            hotel.AddHotel(new Hotel("Bridgewood", 160, 60,4));
            hotel.AddHotel(new Hotel("Ridgewood", 220, 150,5));
            ////Check cheapest available hotel
            Hotel cheapestAvailableHotel = hotel.FindCheapestHotelForGivenTime(startDate, endDate);

            string expected = "Lakewood";
            string actual = cheapestAvailableHotel.hotelName;
            ////Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
