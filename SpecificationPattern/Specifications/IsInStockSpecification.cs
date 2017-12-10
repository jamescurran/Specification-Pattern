using System.Linq;

namespace SpecificationPattern.Specifications
{
    public class IsInStockSpecification : Specification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            return (candidate.OrderItems.Count(item => !item.IsInStock) == 0);
        }
    }
}