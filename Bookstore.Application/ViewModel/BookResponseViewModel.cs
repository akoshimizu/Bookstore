using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Application.ViewModel
{
    public class BookResponseViewModel
    {
        public BookResponseViewModel(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
    }
}