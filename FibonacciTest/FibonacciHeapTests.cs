﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibonacciHeap.Tests
{
    [TestClass()]
    public class FibonacciHeapTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            // Heap
            FibonacciHeap<float, char> heap = new FibonacciHeap<float, char>();

            // Add collection of nodes
            HeapNode<float, char> node2 = heap.Insert(7, 'b');
            HeapNode<float, char> node1 = heap.Insert(3, 'a');
            HeapNode<float, char> node3 = heap.Insert(14, 'c');
            HeapNode<float, char> node4 = heap.Insert(35, 'd');

            // Check minimum is correct, and contains correct values
            Assert.AreEqual(heap.Minimum, node1);
            Assert.AreEqual(heap.Minimum.Priority, 3);
            Assert.AreEqual(heap.Minimum.Value, 'a');
            Assert.AreEqual(heap.Count, 4);

            // Insert new minimum
            HeapNode<float, char> node5 = heap.Insert(2, 'e');

            // Check minimum is correct, and contains correct values
            Assert.AreEqual(heap.Minimum, node5);
            Assert.AreEqual(heap.Minimum.Priority, 2);
            Assert.AreEqual(heap.Minimum.Value, 'e');
            Assert.AreEqual(heap.Count, 5);
        }

        [TestMethod()]
        public void DeleteMinTest()
        {
            // Heap
            FibonacciHeap<float, char> heap = new FibonacciHeap<float, char>();

            // Add collection of nodes
            HeapNode<float, char> node2 = heap.Insert(7, 'b');
            HeapNode<float, char> node1 = heap.Insert(3, 'a');
            HeapNode<float, char> node3 = heap.Insert(14, 'c');
            HeapNode<float, char> node4 = heap.Insert(35, 'd');

            // Check minimum is correct, and contains correct values
            Assert.AreEqual(heap.Minimum, node1);
            Assert.AreEqual(heap.Minimum.Priority, 3);
            Assert.AreEqual(heap.Minimum.Value, 'a');
            Assert.AreEqual(heap.Count, 4);

            // Remove minimum element
            heap.DeleteMin();

            // Check minimum is correct, and contains correct values
            Assert.AreEqual(heap.Minimum, node2);
            Assert.AreEqual(heap.Minimum.Priority, 7);
            Assert.AreEqual(heap.Minimum.Value, 'b');
            Assert.AreEqual(heap.Count, 3);
        }

        [TestMethod()]
        public void DecreasePriorityTest()
        {
            // Heap
            FibonacciHeap<float, char> heap = new FibonacciHeap<float, char>();

            // Add collection of nodes
            HeapNode<float, char> node2 = heap.Insert(7, 'b');
            HeapNode<float, char> node1 = heap.Insert(3, 'a');
            HeapNode<float, char> node3 = heap.Insert(14, 'c');
            HeapNode<float, char> node4 = heap.Insert(35, 'd');

            // Decrease priority of node
            heap.DecreasePriority(node4, 1);

            // Check minimum is correct, and contains correct values
            Assert.AreEqual(heap.Minimum.Priority, 1);
            Assert.AreEqual(heap.Minimum.Value, 'd');
            Assert.AreEqual(heap.Minimum, node4);
            Assert.AreEqual(heap.Count, 4);

            // Delete min so trees are consolidated
            heap.DeleteMin();

            // Decrease priority of node
            heap.DecreasePriority(node2, 0);

            // Check minimum is correct, and contains correct values
            Assert.AreEqual(heap.Minimum, node2);
            Assert.AreEqual(heap.Minimum.Priority, 0);
            Assert.AreEqual(heap.Minimum.Value, 'b');
            Assert.AreEqual(heap.Count, 3);
        }

        [TestMethod()]
        public void PopTest()
        {
            // Heap
            FibonacciHeap<float, char> heap = new FibonacciHeap<float, char>();

            // Check heap starts with no nodes
            Assert.AreEqual(heap.Count, 0);

            // Add collection of nodes
            HeapNode<float, char> node2 = heap.Insert(7, 'b');
            HeapNode<float, char> node1 = heap.Insert(3, 'a');
            HeapNode<float, char> node3 = heap.Insert(14, 'c');
            HeapNode<float, char> node4 = heap.Insert(35, 'd');

            // Check heap has correct number of nodes
            Assert.AreEqual(heap.Count, 4);

            char minimum = heap.Pop();

            // Check returned item is the correct value, and is not still in heap
            Assert.AreEqual(minimum, 'a');
            Assert.AreNotEqual(heap.Minimum.Value, minimum);

            // Check new minimum is correct, and contains correct values
            Assert.AreEqual(heap.Minimum, node2);
            Assert.AreEqual(heap.Minimum.Priority, 7);
            Assert.AreEqual(heap.Minimum.Value, 'b');
            Assert.AreEqual(heap.Count, 3);


            minimum = heap.Pop();

            // Check returned item is the correct value, and is not still in heap
            Assert.AreEqual(minimum, 'b');
            Assert.AreNotEqual(heap.Minimum.Value, minimum);
            Assert.AreEqual(heap.Count, 2);

            minimum = heap.Pop();

            // Check returned item is the correct value, and is not still in heap
            Assert.AreEqual(minimum, 'c');
            Assert.AreNotEqual(heap.Minimum.Value, minimum);
            Assert.AreEqual(heap.Count, 1);

            minimum = heap.Pop();

            // Check returned item is the correct value
            Assert.AreEqual(minimum, 'd');
            Assert.AreEqual(heap.Count, 0);
        }
    }
}