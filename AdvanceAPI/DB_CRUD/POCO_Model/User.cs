﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_CRUD.POCO_Model
{
    // represents employee entity in our application
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}