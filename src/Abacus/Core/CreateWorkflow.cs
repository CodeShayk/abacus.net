namespace Abacus.Core
{
    public static class CreateWorkflow
    {
        public static ITemplate For<TEntity, TTrigger>(string name, string? version = null)
                    where TEntity : IEntityType
                    where TTrigger : ITrigger
        {
            return new Template<TEntity, TTrigger>(name, version);
        }

        public static ITemplate Map<TTask>(this ITemplate workflow, Func<ITransition, ITransition> transition)
        where TTask : ITaskType, new()
        {
            workflow.Root = new Transition<TTask>();
            var child = transition(workflow.Root);
            child.Parent = workflow.Root.Task;
            workflow.Root.Transitions.Add(child);
            return workflow;
        }

        public static ITransition Map<TTriger, TTask>(this ITransition transtion, Func<ITransition, ITransition> dependent)
            where TTriger : ITrigger
            where TTask : ITaskType
        {
            var tran = new Transition<TTriger, TTask>() { Parent = transtion.Task };

            if (dependent != null)
            {
                var child = dependent(tran);
                child.Parent = tran.Task;
                tran.Transitions.Add(child);
            }

            transtion.Transitions.Add(tran);

            return transtion;
        }

        public static ITransition Map<TTriger, TTask>(this ITransition transtion)
           where TTriger : ITrigger
           where TTask : ITaskType
        {
            var tran = new Transition<TTriger, TTask>() { Parent = transtion.Task };
            transtion.Transitions.Add(tran);
            return transtion;
        }
    }
}