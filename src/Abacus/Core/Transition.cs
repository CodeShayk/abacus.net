namespace Abacus.Core
{
    /// <summary>
    /// Workflow Node with trigger to create task and children transitions.
    /// </summary>
    /// <typeparam name="TTask"></typeparam>
    public class Transition<TTrigger, TTask> : ITransition
        where TTask : ITaskType, new()
        where TTrigger : ITrigger, new()
    {
        public Transition()
        {
            Trigger = new TTrigger();
            Task = new TTask();
            Transitions = new List<ITransition>();
        }

        public ITaskType Parent { get; set; }
        public ITrigger Trigger { get; set; }
        public ITaskType Task { get; set; }
        public IList<ITransition> Transitions { get; set; }
    }

    public class Transition<TTask> : ITransition
       where TTask : ITaskType, new()
    {
        public Transition()
        {
            Task = new TTask();
            Transitions = new List<ITransition>();
        }

        public ITaskType Parent { get; set; }
        public ITrigger Trigger { get; set; }
        public ITaskType Task { get; set; }
        public IList<ITransition> Transitions { get; set; }
    }
}