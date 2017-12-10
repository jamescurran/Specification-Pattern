using System;

namespace SpecificationPattern.Specifications
{
    public class DomesticOrderSpecification : Specification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            return candidate.ShippingAddress.Country == "USA";
        }
    }
}