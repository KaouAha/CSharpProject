﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibBLL
{
   public  class ExceptionBLL : Exception
    {
        public ExceptionBLL(string message)
        : base(message)
        {
        }
    }
}