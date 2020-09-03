using System.Collections.Generic;

namespace DemoTypes
{
    public class Buffer<T> : IBuffer<T>
    {
        public Queue<T> _queue { get; set; } = new Queue<T>();

        public bool IsEmpty
        {
            get { return _queue.Count == 0; }
        }

       
        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }

        public T Read()
        {
            return _queue.Dequeue();
        }


    }
}