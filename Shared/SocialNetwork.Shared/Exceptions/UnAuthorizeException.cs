﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Shared.Exceptions
{
    public class UnAuthorizeException : Exception
    {
        public UnAuthorizeException() : base()
        {
        }

        public UnAuthorizeException(string message) : base(message)
        {
        }

        public UnAuthorizeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
