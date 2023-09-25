using System;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string message) : base(message)
        {

        }
    }
}
