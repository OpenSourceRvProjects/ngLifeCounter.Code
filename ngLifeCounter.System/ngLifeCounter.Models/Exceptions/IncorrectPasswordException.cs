﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models.Exceptions
{
	public class IncorrectPasswordException: Exception
	{
        public IncorrectPasswordException(string message) : base (message)
        {
        }
    }
}
