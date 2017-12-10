namespace SpecificationPattern
{
    /// <summary>
    /// AndSpecification&lt;TEntity&gt;
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class AndSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AndSpecification&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right) : base(left,right)
        {
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
            return left.IsSatisfiedBy(candidate) && right.IsSatisfiedBy(candidate);
        }
    }
}