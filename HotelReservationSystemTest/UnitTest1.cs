namespace HotelReservationSystemTest
{
    using HotelReservationSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            hotel.AddHotel(new Hotel("Lakewood", 110));
            hotel.AddHotel(new Hotel("Bridgewood", 160));
            hotel.AddHotel(new Hotel("Ridgewood", 220));

            int expected = 3;
            int actual = hotel.Hotels.Count();

            Assert.AreEqual(expected, actual);
        }
      
    }
}
