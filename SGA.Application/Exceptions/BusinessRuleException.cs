using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Application.Exceptions
{
    public class BusinessRuleException : ApplicationException
    {
        public BusinessRuleException(string message)
            : base(message)
        {

        }
    }
}
