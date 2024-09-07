namespace Abacus.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var obj = new Class1();
            Assert.IsNotNull(obj);
            Assert.Pass();
        }
    }
}