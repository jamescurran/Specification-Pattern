using System.Linq;

namespace SpecificationPattern.Specifications
{
    public static class OrderSpec
    {
        public static readonly Specification<Order> DomesticOrder = Specification<Order>.With(candidate => candidate.ShippingAddress.Country == "USA");
        public static readonly Specification<Order> HighValue = Specification<Order>.With(candidate => candidate.OrderTotal > 100);
        public static readonly Specification<Order> Hazardous = Specification<Order>.With(candidate => candidate.OrderItems.Count(x => x.ContainsHazardousMaterial) > 0);
        public static readonly Specification<Order> InStock = Specification<Order>.With(candidate => candidate.OrderItems.Count(item => !item.IsInStock) == 0);
        public static readonly Specification<Order> RushOrder = Specification<Order>.With(candidate =>
            candidate.Satisifies(DomesticOrder
                .And(HighValue)
                .And(InStock)
                .And(Hazardous.Not())));
    }
}