namespace SpecificationPattern
{
    /// <summary>
    /// Applies the Specification pattern to a type of TEntity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISpecification<TEntity>
    {
        /// <summary>
        /// Determines whether the specified candidate is satisfied by the candidate.
        /// </summary>
        /// <param name="candidate">The candidate.</param>
        /// <returns>
        /// 	<c>true</c> if the specified candidate is satisfied by the candidate; otherwise, <c>false</c>.
        /// </returns>
        bool IsSatisfiedBy(TEntity candidate);

        /// <summary>
        /// Ands the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        ISpecification<TEntity> And(ISpecification<TEntity> other);

        /// <summary>
        /// Ors the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        ISpecification<TEntity> Or(ISpecification<TEntity> other);

        /// <summary>
        /// Nots this instance.
        /// </summary>
        /// <returns></returns>
        ISpecification<TEntity> Not();
    }
}