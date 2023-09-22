using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Api.Hypermedia;
using Bookstore.Api.Hypermedia.Abstract;

namespace Bookstore.Api.ValueObject
{
    public class EditorBookValueObject : ISupportHyperMedia
    {
        public EditorBookValueObject(int? id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public int? Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}