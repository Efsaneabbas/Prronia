using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaBusiness.Exceptions
{
    public class ImageContextTypeException : Exception
    {
        public ImageContextTypeException(string? message) : base(message)
        {
        }
    }
}
