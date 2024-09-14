namespace Abacus.Core
{
    public interface ITransition
    {
        ITaskType Parent { get; set; }
        ITaskType Task { get; set; }
        ITrigger Trigger { get; set; }
        IList<ITransition> Transitions { get; set; }
    }
}