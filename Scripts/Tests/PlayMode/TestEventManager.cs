using NUnit.Framework;

namespace MPewsey.UnityEventManager.Tests.PlayMode
{
    public class TestEventManager
    {
        private int Counter { get; set; }

        [SetUp]
        public void SetUp()
        {
            Counter = 0;
        }

        [TearDown]
        public void TearDown()
        {
            EventManager.Clear();
        }

        [Test]
        public void TestRemoveAllListeners()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener("Test", IncrementCounter);
            EventManager.RemoveAllListeners("Test");
            EventManager.Invoke("Test");
            Assert.AreEqual(0, Counter);
        }

        [Test]
        public void TestRemoveAllListenersT1()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener<int>("Test", AddToCounter);
            EventManager.RemoveAllListeners<int>("Test");
            EventManager.Invoke("Test", 1);
            Assert.AreEqual(0, Counter);
        }

        [Test]
        public void TestRemoveAllListenersT2()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener<int, int>("Test", AddToCounter);
            EventManager.RemoveAllListeners<int, int>("Test");
            EventManager.Invoke("Test", 1, 2);
            Assert.AreEqual(0, Counter);
        }

        [Test]
        public void TestRemoveAllListenersT3()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener<int, int, int>("Test", AddToCounter);
            EventManager.RemoveAllListeners<int, int, int>("Test");
            EventManager.Invoke("Test", 1, 2, 3);
            Assert.AreEqual(0, Counter);
        }

        [Test]
        public void TestRemoveListener()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener("Test", IncrementCounter);
            EventManager.RemoveListener("Test", IncrementCounter);
            EventManager.Invoke("Test");
            Assert.AreEqual(0, Counter);
        }

        [Test]
        public void TestRemoveListenerT1()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener<int>("Test", AddToCounter);
            EventManager.RemoveListener<int>("Test", AddToCounter);
            EventManager.Invoke("Test", 1);
            Assert.AreEqual(0, Counter);
        }

        [Test]
        public void TestRemoveListenerT2()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener<int, int>("Test", AddToCounter);
            EventManager.RemoveListener<int, int>("Test", AddToCounter);
            EventManager.Invoke("Test", 1, 2);
            Assert.AreEqual(0, Counter);
        }

        [Test]
        public void TestRemoveListenerT3()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener<int, int, int>("Test", AddToCounter);
            EventManager.RemoveListener<int, int, int>("Test", AddToCounter);
            EventManager.Invoke("Test", 1, 2, 3);
            Assert.AreEqual(0, Counter);
        }

        [Test]
        public void TestInvoke()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener("Test", IncrementCounter);
            EventManager.Invoke("Test");
            Assert.AreEqual(1, Counter);
        }

        [Test]
        public void TestInvokeT1()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener<int>("Test", AddToCounter);
            EventManager.Invoke("Test", 100);
            Assert.AreEqual(100, Counter);
        }

        [Test]
        public void TestInvokeT2()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener<int, int>("Test", AddToCounter);
            EventManager.Invoke("Test", 100, 200);
            Assert.AreEqual(300, Counter);
        }

        [Test]
        public void TestInvokeT3()
        {
            Assert.AreEqual(0, Counter);
            EventManager.AddListener<int, int, int>("Test", AddToCounter);
            EventManager.Invoke("Test", 100, 200, 300);
            Assert.AreEqual(600, Counter);
        }

        [Test]
        public void TestThrowsInvalidCastException()
        {
            EventManager.AddListener("Test", IncrementCounter);
            EventManager.AddListener<int>("Testing", AddToCounter);
            Assert.Throws<System.InvalidCastException>(() => EventManager.AddListener("Testing", IncrementCounter));
            Assert.Throws<System.InvalidCastException>(() => EventManager.AddListener<int>("Test", AddToCounter));
            Assert.Throws<System.InvalidCastException>(() => EventManager.AddListener<int, int>("Test", AddToCounter));
            Assert.Throws<System.InvalidCastException>(() => EventManager.AddListener<int, int, int>("Test", AddToCounter));
        }

        private void IncrementCounter()
        {
            Counter++;
        }

        private void AddToCounter(int value1)
        {
            Counter += value1;
        }

        private void AddToCounter(int value1, int value2)
        {
            Counter += value1 + value2;
        }

        private void AddToCounter(int value1, int value2, int value3)
        {
            Counter += value1 + value2 + value3;
        }
    }
}