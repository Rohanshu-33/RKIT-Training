using System;
using System.Collections;

namespace CollectionsApp
{
    internal class QueueDemo
    {
        internal static void QueueMethods()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // Get the count of items in the queue
            Console.WriteLine("Length of the queue: " + queue.Count);

            // Peek at the front element without removing it
            int front = queue.Peek();
            Console.WriteLine("Front element: " + front);

            // Dequeue an element (removes it from the queue)
            int removed = queue.Dequeue();
            Console.WriteLine("Removed element: " + removed);

            // Check if the queue contains a specific element
            bool contains = queue.Contains(2);
            Console.WriteLine("Contains 2: " + contains);

            // Iterate through the queue
            Console.WriteLine("Queue contents:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            // Aggregate operation (sum of all elements)
            int sum = queue.Aggregate(0, (acc, item) => acc + item);
            Console.WriteLine("Sum of queue elements: " + sum);

            // Demonstrate `TryDequeue`
            if (queue.TryDequeue(out int dequeued))
            {
                Console.WriteLine("Successfully dequeued: " + dequeued);
            }
            else
            {
                Console.WriteLine("Queue is empty. Nothing to dequeue.");
            }

            // Demonstrate `TryPeek`
            if (queue.TryPeek(out int peeked))
            {
                Console.WriteLine("Successfully peeked: " + peeked);
            }
            else
            {
                Console.WriteLine("Queue is empty. Nothing to peek.");
            }

            // Add elements back to the queue
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            // Use `TrimExcess` to reduce memory overhead
            Console.WriteLine("Queue capacity before TrimExcess: (internal info)");
            queue.TrimExcess();
            Console.WriteLine("TrimExcess called to reduce memory overhead.");

            // Convert the queue to an array
            int[] arr = queue.ToArray();
            
        }
    }
}
