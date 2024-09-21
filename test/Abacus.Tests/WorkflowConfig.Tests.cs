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
        }

        [Test]
        public void TestConfigWithMapExtensions()
        {
            leadWorkflow = CreateWorkflow.For<Lead, LeadCreated>("LeadWorkflow")
                           .StartWith<CreateOpportunity>((root) => root
                               .Map<PassThrough, ArrangeAppointment>((appointment) => appointment
                                   .Map<LeadNotInterested, RemoveOpportunity>()
                                   .Map<LeadInterested, SellProduct>((sellproduct) => sellproduct
                                           .Map<LeadNotPurchased, RemoveOpportunity>()
                                           .Map<LeadPurchased, CreateCustomer>()
                                    )
                                )
                            );

            //need to assert on config
            Assert.IsNotNull(leadWorkflow);
        }

        [Test]
        public void TestConfigWithCreateTaskExtensions()
        {
            leadWorkflow = CreateWorkflow.For<Lead, LeadCreated>("LeadWorkflow")
                           .StartWith<CreateOpportunity>((root) => root
                               .CreateTask<ArrangeAppointment>(With.NoTrigger(), (appointment) => appointment
                                   .CreateTask<RemoveOpportunity>(With.Trigger<LeadNotInterested>())
                                   .CreateTask<SellProduct>(With.Trigger<LeadInterested>(), (sellproduct) => sellproduct
                                           .CreateTask<RemoveOpportunity>(With.Trigger<LeadNotPurchased>())
                                           .CreateTask<CreateCustomer>(With.Trigger<LeadPurchased>())
                                    )
                                )
                            );

            //need to assert on config
            Assert.IsNotNull(leadWorkflow);
        }

        [Test]
        public void TestConfigWithCreateTaskCompletionExtensions()
        {
            leadWorkflow = CreateWorkflow.For<Lead, LeadCreated>("LeadWorkflow")
                          .StartWith<CreateOpportunity>((root) => root
                              .CreateTask<ArrangeAppointment>(With.NoTrigger(), (appointment) => appointment
                                  .CreateTask<RemoveOpportunity>(With.Trigger<LeadNotInterested>())
                                  .CreateTask<SellProduct>(With.Trigger<LeadInterested>(), (sellproduct) => sellproduct
                                          .CreateTask<RemoveOpportunity>(With.Trigger<LeadNotPurchased>())
                                          .CreateTask<CreateCustomer>(With.Trigger<LeadPurchased>())
                                   )
                               )
                           );

            //need to assert on config
            Assert.IsNotNull(leadWorkflow);
        }
    }
}