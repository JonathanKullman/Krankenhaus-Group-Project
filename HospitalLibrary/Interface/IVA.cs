﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    class IVA : IDepartment
    {
        public int Risk { get; set; }
        public int Chance { get; set; }
        public int Unchanged { get; set; }
    }
}