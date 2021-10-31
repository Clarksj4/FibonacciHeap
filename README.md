# [Fibonacci Heap](https://en.wikipedia.org/wiki/Fibonacci_heap)

## Understanding Dijkstra's shortest path algorithm
[Here](https://github.com/Clarksj4/Pathfind) is an example use of this Fibonacci Heap in implementing Dijkstra's shortest path algorithm.

## Overview
A Fibonacci heap is an implementation of a priority queue designed with Dijkstra's shortest path algorithm in mind. It provides better time complexity than a binary heap (another implementation of a priority queue) by lazily defering consolidation of its internal tree structure until the deleteMin operation.

Listed below are the four operations that a Fibonacci heap supports, and their associated time complexity as compared to a binary heap.


Operation        | Binary Heap | Fibonacci Heap
-----------------|:-----------:|:--------------:
insert           | O(log n)    | O(1)
findMin          | O(1)        | O(1)
deleteMin        | O(log n)    | O(log n)
decreasePriority | O(log n)    | O(1)

Here are some resources to help understand a Fibonacci heap:
- https://www.cs.princeton.edu/~wayne/teaching/fibonacci-heap.pdf
- https://www.cs.princeton.edu/courses/archive/spring13/cos423/lectures/FibonacciHeaps-2x2.pdf

## Usage


### Insert

Each item inserted into a Fibonacci heap requires an associated priorty. This determines the order in which it is stored. Use of generics means the priorty can be any type that implements the IComparable interface. The second type argument is the type of the object being stored in the heap.

    using FibonacciHeap;
    
    public void InsertExample()
    {
        // Create an empty heap. First type is the priority, second type is the type of the object being stored
        FibonacciHeap<int, string> heap = new FibonacciHeap<int, string>();
    
        // Insert "hello" into heap at priority 3
        HeapNode<int, string> node1 = heap.Insert(3, "hello");
        
        // Insert "world" into heap at priority 7
        HeapNode<int, string> node2 = heap.Insert(7, "world");
        
        ...
    }
    
The insert method returns a HeapNode which contains the item being stored as well as its priority. A reference to the inserted node is necessary should you want to decrease the priority of the node at a later stage
    
### Find Min

The purpose of a priority queue is to always be able to access the item with the smallest priority. This is done by calling the heap's Minimum property

    public void FindMinExample()
    {
        // Create an empty heap.
        FibonacciHeap<int, string> heap = new FibonacciHeap<int, string>();
                
        // Insert two items into heap
        HeapNode<int, string> node1 = heap.Insert(3, "hello");
        HeapNode<int, string> node2 = heap.Insert(7, "world");
        
        // Get the node with the lowest priority
        HeapNode<int, string> minNode = heap.Minimum;
        
        // minNode priority is 3
        // minNode value is "hello"
        
        ...
    }
    
### Delete Min

A Fibonacci Heap allows removal of the least priority item. Once removed, the next least priority item will takes its place as the Minimum.

    public void DeleteMinExample()
    {
        // Create an empty heap.
        FibonacciHeap<int, string> heap = new FibonacciHeap<int, string>();
                
        // Insert two items into heap
        HeapNode<int, string> node1 = heap.Insert(3, "hello");
        HeapNode<int, string> node2 = heap.Insert(7, "world");
        
        // Get the node with the lowest priority
        HeapNode<int, string> minNode = heap.Minimum;
        
        // minNode priority is 3
        // minNode value is "hello"
        
        // Remove the node with the lowest priority
        heap.DeleteMin();
        
        minNode = heap.Minimum;
        
        // minNode priority is 7
        // minNode value is "world"
        
        ...
    }
    
### Pop

For convenience, the pop method removes and returns the lowest priority item from the heap.

    public void PopExample()
    {
        // Create an empty heap.
        FibonacciHeap<int, string> heap = new FibonacciHeap<int, string>();
                
        // Insert two items into heap
        HeapNode<int, string> node1 = heap.Insert(3, "hello");
        HeapNode<int, string> node2 = heap.Insert(7, "world");
        
        string minValue = heap.Pop()
        
        // minValue is "hello"
        
        minNode = heap.Minimum;
        
        // minNode priority is 7
        // minNode value is "world"
        
        ...
    }
    
### Decrease Priority

It is possible to decrease the priority of a node in the heap. A reference to the node is returned when the associated item is inserted into the heap.

    public void DecreasePriorityExample()
    {
        // Create an empty heap.
        FibonacciHeap<int, string> heap = new FibonacciHeap<int, string>();
                
        // Insert two items into heap. Insert method returned ref to stored node.
        HeapNode<int, string> node1 = heap.Insert(3, "hello");
        HeapNode<int, string> node2 = heap.Insert(7, "world");
        
        minNode = heap.Minimum;
        
        // minNode priority is 3
        // minNode value is "hello"
        
        // Decease node2's priority to 1
        heap.DecreasePriority(node2, 1);
        
        minNode = heap.Minimum;
        
        // minNode priority is 1
        // minNode value is "world"
        
        ...
    }
