using SpecificationPattern.Specifications;
using System.Linq;

namespace SpecificationPattern.Specifications
{
    public class RushOrderSpecification : Specification<Order>
    {
        readonly Specification<Order> domesticOrderSpec = Specification<Order>.With(candidate => candidate.ShippingAddress.Country == "USA");
        readonly Specification<Order> highValueSpec =           Specification<Order>.With(candidate => candidate.OrderTotal > 100);
        readonly Specification<Order> hazardousSpec =           Specification<Order>.With(candidate => candidate.OrderItems.Count(x => x.ContainsHazardousMaterial) > 0);
        readonly Specification<Order> inStockSpec =              Specification<Order>.With(candidate => candidate.OrderItems.Count(item => !item.IsInStock) == 0);

        public override bool IsSatisfiedBy(Order candidate)
        {
            return domesticOrderSpec
                .And(highValueSpec)
                .And(inStockSpec)
                .And(hazardousSpec.Not())
                .IsSatisfiedBy(candidate);
        }
    }
}