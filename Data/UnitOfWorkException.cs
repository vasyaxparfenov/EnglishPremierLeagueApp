using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class UnitOfWorkException : Exception
    {
        public UnitOfWorkException(string message) : base(message)
        {
            
        }
    }
}
