namespace Abacus.Core
{
    public interface ITaskTrigger<in TTaskType, in TOutcomeType> : ITrigger
        where TTaskType : ITaskType
        where TOutcomeType : IOutcomeType
    {
    }

    public interface ITaskTrigger<in TTask> : ITrigger
        where TTask : ITaskType, new()
    {
        IOutcomeType Outcome { get; set; }
    }
}