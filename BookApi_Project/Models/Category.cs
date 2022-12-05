﻿using System.Collections.Generic;

namespace BookApi_Project.Models
{
    public class Category
    {
        public int Id
        {
            get; set;
        }
        public string Name { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
