using System;
using System.Linq;
using System.Collections.Generic;
using SpecificationPattern.Specifications;

namespace SpecificationPattern
{
    public class Order : ISpecificationTarget<Order>
    {
        public Order()
        {
            OrderItems = new List<Product>();
        }

        public virtual Address ShippingAddress { get; set; }
        public int OrderTotal{ get; set; }
        public IList<Product> OrderItems { get; set; }

        public bool IsRush()
        {
            var spec = new RushOrderSpecification();
            return this.Satisifies(spec);
        }
    }
}