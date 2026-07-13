using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Application.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) 
            : base(message)
        {

        }
    }
}
