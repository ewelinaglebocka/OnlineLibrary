﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> BooksWriten { get; set; }
        public Author()
        {
            BooksWriten = new List<Book>();
        }
    }
}
