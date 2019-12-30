using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Web.Exceptions
{
    public class GraphQLException : ApplicationException
    {
        public GraphQLException(string message) : base(message)
        {
        }
    }
}
