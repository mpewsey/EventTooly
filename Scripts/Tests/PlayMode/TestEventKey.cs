using NUnit.Framework;

namespace MPewsey.UnityEventManager.Tests.PlayMode
{
    public class TestEventKey
    {
        [Test]
        public void TestToString()
        {
            var key = new EventKey("Test");
            Assert.AreEqual("EventKey(Test)", key.ToString());
        }

        [Test]
        public void TestEquals()
        {
            var key1 = new EventKey("Test");
            var key2 = new EventKey("Test");
            Assert.AreEqual(key1, key2);
        }

        [Test]
        public void TestAreNotEqual()
        {
            var key1 = new EventKey("Test1");
            var key2 = new EventKey("Test2");
            Assert.AreNotEqual(key1, key2);
        }
    }
}