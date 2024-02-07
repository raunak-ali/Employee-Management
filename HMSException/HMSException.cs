using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSException;



    public class HMSException : ApplicationException
    {
        public HMSException() : base() { }

        public HMSException(string message) : base(message) { }

        public HMSException(string message, Exception innerException) : base(message, innerException) { }
    }

