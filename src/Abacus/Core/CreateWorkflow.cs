using System.Net.NetworkInformation;

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

        public static ITemplate StartWith<TTask>(this ITemplate workflow, Func<ITransition, ITransition> withTransition = null)
        where TTask : ITaskType, new()
        {
            workflow.Root = new Transition<TTask>();

            if (withTransition != null)
            {
                var child = withTransition(workflow.Root);
                child.Parent = workflow.Root.Task;
                workflow.Root.Transitions.Add(child);
            }

            return workflow;
        }

        public static ITransition CreateTask<TTask>(this ITransition transtion, ITrigger trigger, Func<ITransition, ITransition> withTransition = null)
           where TTask : ITaskType, new()
        {
            var tran = new Transition<TTask>() { Trigger = trigger, Parent = transtion.Task };

            if (withTransition != null)
            {
                var child = withTransition(tran);
                child.Parent = tran.Task;
                tran.Transitions.Add(child);
            }

            transtion.Transitions.Add(tran);

            return transtion;
        }

        public static ITransition Map<TTriger, TTask>(this ITransition transtion, Func<ITransition, ITransition> withTransition = null)
            where TTriger : ITrigger, new()
            where TTask : ITaskType, new()
        {
            var tran = new Transition<TTriger, TTask>() { Parent = transtion.Task };

            if (withTransition != null)
            {
                var child = withTransition(tran);
                child.Parent = tran.Task;
                tran.Transitions.Add(child);
            }

            transtion.Transitions.Add(tran);

            return transtion;
        }

        public static ITransition CreateTask<TTask>(this ITransition transtion, ITrigger trigger)
             where TTask : ITaskType, new()
        {
            var tran = new Transition<TTask>() { Parent = transtion.Task };
            transtion.Transitions.Add(tran);
            return transtion;
        }
    }

    public class With
    {
        public static ITrigger NoTrigger() => null;

        //    public static ITrigger Trigger<TTrigger>(IOutcomeType outcome=null)
        //        where TTrigger : ITaskTrigger, new() => new TTrigger();
        //}

        public static class On
        {
            public static ITransition Completion(ITransition parent, Func<ITransition> followtask)
            {
                var tran = followtask();
                tran.Parent = parent.Task;

                parent.Transitions.Add(tran);
                return parent;
            }
        }

        //public static class Create
        //{
        //    public static ITransition Task<TTask>(ITrigger trigger, Func<ITransition, ITransition> withTransition = null)
        //                 where TTask : ITaskType, new()
        //    {
        //        var tran = new Transition<TTask>() { Trigger = trigger, Parent = transtion.Task };

        //        if (withTransition != null)
        //        {
        //            var child = withTransition(tran);
        //            child.Parent = tran.Task;
        //            tran.Transitions.Add(child);
        //        }

        //        transtion.Transitions.Add(tran);

        //        return transtion;
        //    }
        //}

        public static class OnCompletion
        {
            public static ITransition CreateTask<TTask>(ITransition transtion, ITrigger trigger, Func<ITransition, ITransition> withTransition = null)
              where TTask : ITaskType, new()
            {
                var tran = new Transition<TTask>() { Trigger = trigger, Parent = transtion.Task };

                if (withTransition != null)
                {
                    var child = withTransition(tran);
                    child.Parent = tran.Task;
                    tran.Transitions.Add(child);
                }

                transtion.Transitions.Add(tran);

                return transtion;
            }
        }
    }