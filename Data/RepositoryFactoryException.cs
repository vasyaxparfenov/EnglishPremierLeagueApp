using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
   public class RepositoryFactoryException : Exception
    {
        public RepositoryFactoryException(string message) : base(message) { }
    }
}
