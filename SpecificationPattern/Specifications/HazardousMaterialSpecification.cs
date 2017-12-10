using System.Linq;

namespace SpecificationPattern.Specifications
{
    public class HazardousMaterialSpecification : Specification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            return (candidate.OrderItems.Count(x => x.ContainsHazardousMaterial) > 0);
        }
    }
}