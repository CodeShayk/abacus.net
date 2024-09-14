namespace Abacus.Core
{
    public interface IEntityTrigger<in TEntity> : ITrigger
        where TEntity : IEntityType
    {
    }
}