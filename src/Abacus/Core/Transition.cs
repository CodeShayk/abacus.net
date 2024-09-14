namespace Abacus.Core
{
    /// <summary>
    /// Workflow Node with trigger to create task and children transitions.
    /// </summary>
    /// <typeparam name="TTask"></typeparam>
    public class Transition<TTrigger, TTask> : ITransition
        where TTask : ITaskType
        where TTrigger : ITrigger
    {
        public ITaskType Parent { get; set; }
        public ITrigger Trigger { get; set; }
        public ITaskType Task { get; set; }
        public IList<ITransition> Transitions { get; set; }
    }

    public class Transition<TTask> : ITransition
       where TTask : ITaskType
    {
        public ITaskType Parent { get; set; }
        public ITrigger Trigger { get; set; }
        public ITaskType Task { get; set; }
        public IList<ITransition> Transitions { get; set; }
    }
}