﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin 
{
    internal class UserContext : DbContext
    {
        public UserContext()
: base(Properties.Settings.Default.DbConnect)
       
        { }
   
    }
}
