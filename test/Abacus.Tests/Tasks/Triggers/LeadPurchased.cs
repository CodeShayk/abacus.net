using Abacus.Core;
using Abacus.Tests.Tasks.Outcomes;

namespace Abacus.Tests.Tasks.Triggers
{
    internal class LeadPurchased : ITaskTrigger<SellProduct, PurchasedProduct>
    {
    }

    internal class LeadNotPurchased : ITaskTrigger<SellProduct, NotInterested>
    {
    }

    internal class LeadNotInterested : ITaskTrigger<ArrangeAppointment, NotInterested>
    {
    }

    internal class LeadInterested : ITaskTrigger<ArrangeAppointment, Interested>
    {
    }
}