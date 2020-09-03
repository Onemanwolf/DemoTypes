using System.Collections.Generic;

namespace DemoTypes
{
    public interface IBuffer<T>
    {

        Queue<T> _queue {get; set;}
        bool IsEmpty { get; }

        T Read();
        void Write(T value);
    }
}