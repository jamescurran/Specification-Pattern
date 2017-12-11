namespace SpecificationPattern
{
    public static class SpecExt
    {
        public static bool Satisifies<TEntity>(this TEntity obj, ISpecification<TEntity> cond)
            where TEntity : ISpecificationTarget<TEntity>
        {
            return cond.IsSatisfiedBy(obj);
        }
    }

}