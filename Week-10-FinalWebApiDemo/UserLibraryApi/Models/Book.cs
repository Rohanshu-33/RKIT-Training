﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserLibraryApi.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
    }
}