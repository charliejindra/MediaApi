﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaApi.Helpers
{
    public class systemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }
    }
}
