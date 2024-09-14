using Abacus.Core;
using Abacus.Tests.Entities;
using Abacus.Tests.Entities.Triggers;
using Abacus.Tests.Tasks;
using Abacus.Tests.Tasks.Triggers;

namespace Abacus.Tests
{
    public class WorkflowConfigTests
    {
        private ITemplate leadWorkflow;

        [SetUp]
        public void Setup()
        {
            leadWorkflow = CreateWorkflow.For<Lead, LeadCreated>("LeadWorkflow")
                            .Map<CreateOpportunity>((root) => root
                                .Map<PassThrough, ArrangeAppointment>((appointment) => appointment
                                    .Map<LeadNotInterested, RemoveOpportunity>()
                                    .Map<LeadInterested, SellProduct>((sellproduct) => sellproduct
                                            .Map<LeadNotPurchased, RemoveOpportunity>()
                                            .Map<LeadPurchased, CreateCustomer>()
                                     )
                                 )
                             );
        }

        [Test]
        public void Test1()
        {
            //need to assert on config
            Assert.IsNotNull(leadWorkflow);
        }
    }
}