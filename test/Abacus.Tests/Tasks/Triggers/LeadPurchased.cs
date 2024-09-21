using Abacus.Core;
using Abacus.Tests.Tasks.Outcomes;

namespace Abacus.Tests.Tasks.Triggers
{
    internal class LeadPurchased : ITaskTrigger<SellProduct, PurchasedProduct>
    {
    }
}