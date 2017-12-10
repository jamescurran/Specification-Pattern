using System;

namespace SpecificationPattern
{
    public class SpecificationBuilder<T> : Specification<T>
    {
        private readonly Func<T, bool> _conditional;
        public SpecificationBuilder(Func<T, bool> condition)
        {
            _conditional = condition;
        }
        public override bool IsSatisfiedBy(T candidate)
        {
            return _conditional(candidate);
        }
    }
}