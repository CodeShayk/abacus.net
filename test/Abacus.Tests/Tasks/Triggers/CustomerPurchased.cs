using Abacus.Core;
using Abacus.Tests.Tasks.Outcomes;

namespace Abacus.Tests.Tasks.Triggers
{
    internal class CustomerPurchased : ITaskTrigger<SellServicePlan, PurchasedProduct>
    {
    }

    internal class PassThrough : ITrigger
    {
    }
}