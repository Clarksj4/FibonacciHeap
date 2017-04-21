using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibonacciHeap.Tests
{
    [TestClass()]
    public class BucketTests
    {
        [TestMethod()]
        public void GetTest()
        {
            Bucket<string> bucket = new Bucket<string>();

            // Check that getting an element that has not been set, is null
            Assert.IsNull(bucket[0]);

            // Check that added element is returned, check that initial element has not been edited
            bucket[3] = "Potato";
            Assert.AreEqual(bucket[3], "Potato");
            Assert.IsNull(bucket[0]);
        }

        [TestMethod()]
        public void SetTest()
        {
            Bucket<string> bucket = new Bucket<string>();

            // Check that element is null initially
            Assert.IsNull(bucket[2]);

            // Check that bucket retains set element
            bucket[2] = "Potato";
            Assert.AreEqual(bucket[2], "Potato");

            // Check that bucket overwrites element
            bucket[2] = "Tomato";
            Assert.AreEqual(bucket[2], "Tomato");
        }
    }
}