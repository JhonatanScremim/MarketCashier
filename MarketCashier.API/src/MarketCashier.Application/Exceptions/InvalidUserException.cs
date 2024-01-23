using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketCashier.Application.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string message) : base(message) { } 
    }
}