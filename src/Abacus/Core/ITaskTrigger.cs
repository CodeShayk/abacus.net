namespace Abacus.Core
{
    public interface ITaskTrigger<in TTaskType, in TOutcomeType> : ITrigger
        where TTaskType : ITaskType
        where TOutcomeType : IOutcomeType
    {
    }
}