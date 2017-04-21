using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibonacciHeap.Tests
{
    [TestClass()]
    public class HeapNodeTests
    {
        [TestMethod()]
        public void HeapNodeTest()
        {
            HeapNode<float, string> node = new HeapNode<float, string>(3, "Potato");

            // Check state of properties
            Assert.IsNull(node.Parent);
            Assert.AreEqual(node.Children.Count, 0);
            Assert.IsFalse(node.Marked);
            Assert.AreEqual(node.Rank, 0);
            Assert.AreEqual(node.Priority, 3);
            Assert.AreEqual(node.Value, "Potato");
        }

        [TestMethod()]
        public void AddChildTest()
        {
            // Parent node
            HeapNode<float, string> node = new HeapNode<float, string>(0, "Potato");

            // Add first child
            HeapNode<float, string> child1 = new HeapNode<float, string>(2, "Tomato");
            node.AddChild(child1);

            Assert.AreEqual(child1.Parent, node);            // Child is child of node
            Assert.AreEqual(node.Children.Count, 1);         // Node has one child
            Assert.IsTrue(node.Children.Contains(child1));   // Node has child as a child
            Assert.AreEqual(node.Rank, 1);                   // Rank reflects number of children

            // Add second child
            HeapNode<float, string> child2 = new HeapNode<float, string>(7, "Orange");
            node.AddChild(child2);

            Assert.AreEqual(child2.Parent, node);            // Child is child of node
            Assert.AreEqual(node.Children.Count, 2);         // Node has one child
            Assert.IsTrue(node.Children.Contains(child1));   // Node has child1 as a child
            Assert.IsTrue(node.Children.Contains(child2));   // Node has child2 as a child
            Assert.AreEqual(node.Rank, 2);                   // Rank reflects number of children
        }

        [TestMethod()]
        public void RemoveChildTest()
        {
            // Parent node
            HeapNode<float, string> node = new HeapNode<float, string>(0, "Potato");

            // Add and remove child
            HeapNode<float, string> child = new HeapNode<float, string>(2, "Tomato");
            node.AddChild(child);
            node.RemoveChild(child);

            Assert.IsNull(child.Parent);                    // Child has no parent
            Assert.AreEqual(node.Children.Count, 0);        // Node has no children
            Assert.IsFalse(node.Children.Contains(child));  // Child is not a child of node
            Assert.AreEqual(node.Rank, 0);                  // Rank reflects number of children
        }

        [TestMethod()]
        public void RemoveParentTest()
        {
            // Parent node
            HeapNode<float, string> node = new HeapNode<float, string>(0, "Potato");

            // Add child, remove parent
            HeapNode<float, string> child = new HeapNode<float, string>(2, "Tomato");
            node.AddChild(child);
            child.RemoveParent();

            Assert.IsNull(child.Parent);                    // Child has no parent
            Assert.AreEqual(node.Children.Count, 0);        // Node has no children
            Assert.IsFalse(node.Children.Contains(child));  // Child is not a child of node
            Assert.AreEqual(node.Rank, 0);                  // Rank reflects number of children
        }
    }
}