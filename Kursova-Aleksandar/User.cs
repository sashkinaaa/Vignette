﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursova_Aleksandar
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Rights { get; set; }
    }
}