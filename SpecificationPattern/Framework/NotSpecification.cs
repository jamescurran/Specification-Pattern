namespace SpecificationPattern
{
    /// <summary>
    /// NotSpecification&lt;TEntity&gt;
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class NotSpecification<TEntity> : Specification<TEntity>
    {
        private readonly ISpecification<TEntity> specification;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="specification">The specification.</param>
        public NotSpecification(ISpecification<TEntity> specification)
        {
            this.specification = specification;
        }

        /// <summary>
        /// Determines whether the specified candidate is satisfied by TEntity.
        /// </summary>
        /// <param name="candidate">The candidate.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified candidate]; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return !specification.IsSatisfiedBy(candidate);
        }
    }
}