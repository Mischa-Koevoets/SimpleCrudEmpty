﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Model
{
    internal class Book
    {
        public int id { get; set; }
        public string Name { get; set; }

        public Book(string Name)
        {
            this.Name = Name;
        }
    }
}
