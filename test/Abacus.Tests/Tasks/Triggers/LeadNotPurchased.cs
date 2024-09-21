using Abacus.Core;
using Abacus.Tests.Tasks.Outcomes;

namespace Abacus.Tests.Tasks.Triggers
{
    internal class LeadNotPurchased : ITaskTrigger<SellProduct>
    {
        public IOutcomeType Outcome { get; set; } = new NotInterested();
    }
}