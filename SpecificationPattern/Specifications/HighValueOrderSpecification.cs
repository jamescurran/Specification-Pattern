using System;

namespace SpecificationPattern.Specifications
{
    public class HighValueOrderSpecification : Specification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            return candidate.OrderTotal > 100;
        }
    }
}