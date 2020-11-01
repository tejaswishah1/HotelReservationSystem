using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class CustomException : Exception
    {
        /// <summary>
        /// Enum For Exception type.
        /// </summary>
        public enum ExceptionType
        {
           INVALID_NAME,
           NULL_NAME,
        }

        ExceptionType type;

        /// <summary>
        /// Parameter Constructor For Setting Exception type And Throwing Exception.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public CustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
