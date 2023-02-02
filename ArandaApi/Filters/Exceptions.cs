using System;

namespace ArandaApi.Filters
{
    public class Exceptions
    {
        public class BusinessException : Exception
        {
            public BusinessException()
            {
            }

            public BusinessException(string message) : base(message)
            {

            }

        }
    }
}