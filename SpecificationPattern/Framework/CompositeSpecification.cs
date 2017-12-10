namespace SpecificationPattern
{
    /// <summary>
    /// CompositeSpecification&lt;TEntity&gt;
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ISpecification<TEntity> left;

        /// <summary>
        /// 
        /// </summary>
        protected readonly ISpecification<TEntity> right;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeSpecification&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        protected CompositeSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            this.left = left;
            this.right = right;
        }
    }
}