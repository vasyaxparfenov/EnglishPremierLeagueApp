using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class UnitOfWorkFactoryException : Exception
    {
        public UnitOfWorkFactoryException(string message) : base(message)
        {
            
        }
    }
}
