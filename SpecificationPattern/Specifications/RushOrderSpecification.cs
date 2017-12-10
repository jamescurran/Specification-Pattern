using SpecificationPattern.Specifications;

namespace SpecificationPattern.Specifications
{
    public class RushOrderSpecification : Specification<Order>
    {
        readonly DomesticOrderSpecification domesticOrderSpec = new DomesticOrderSpecification();
        readonly HighValueOrderSpecification highValueSpec = new HighValueOrderSpecification();
        readonly HazardousMaterialSpecification hazardousSpec = new HazardousMaterialSpecification();
        readonly IsInStockSpecification inStockSpec = new IsInStockSpecification();

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