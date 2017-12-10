using System;

namespace SpecificationPattern
{
    /// <summary>
    /// Abstraction on <c>ISpecification</c> that supplies And, Or and Not.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class Specification<TEntity> : ISpecification<TEntity>
    {
        /// <summary>
        /// Determines whether the specified candidate is satisfied by TEntity.
        /// </summary>
        /// <param name="candidate">The candidate.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified candidate]; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsSatisfiedBy(TEntity candidate);

        /// <summary>
        /// Ands the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public ISpecification<TEntity> And(ISpecification<TEntity> specification)
        {
            return new AndSpecification<TEntity>(this, specification);
        }

        /// <summary>
        /// Ors the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public ISpecification<TEntity> Or(ISpecification<TEntity> specification)
        {
            return new OrSpecification<TEntity>(this, specification);
        }

        /// <summary>
        /// Nots this instance.
        /// </summary>
        /// <returns></returns>
        public ISpecification<TEntity> Not()
        {
            return new NotSpecification<TEntity>(this);
        }


        public static SpecificationBuilder<TEntity> With(Func<TEntity, bool> conditional)
        {
            return new SpecificationBuilder<TEntity>(conditional);
        }
    }
}