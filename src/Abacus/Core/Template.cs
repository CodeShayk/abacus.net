namespace Abacus.Core
{
    public class Template<TEnity, TTrigger> : ITemplate
        where TEnity : IEntityType
        where TTrigger : ITrigger
    {
        public Template(string name, string? version = null)
        {
            Name = name;
            Version = !string.IsNullOrEmpty(version) ? version : "1";
        }

        /// <summary>
        /// Name of the Workflow
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Version of Workflow
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Workflow whether Archived.
        /// </summary>
        public bool IsArchived { get; }

        /// <summary>
        /// Entity type associated with this Workflow.
        /// </summary>
        public Type EntiyType { get; } = typeof(TEnity);

        /// <summary>
        /// Trigger type for this workflow.
        /// </summary>
        public Type TriggerType { get; } = typeof(TTrigger);

        /// <summary>
        /// First Task executed as root with this workflow.
        /// </summary>
        public ITransition Root { get; set; }

        ///// <summary>
        ///// List of Task Transitions included with this Workflow.
        ///// </summary>
        //public IList<ITransition> Transitions { get; set; }
    }
}