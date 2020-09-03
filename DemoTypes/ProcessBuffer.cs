using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTypes
{
    public class ProcessBuffer<T>
    {
        public string MyString { get; set;}

        public T Result { get; set;}
        public IEnumerable<string> Strings { get; set;}

        public void Process(IBuffer<T> buffer)
        {
            dynamic sum = 0.0;
            while (!buffer.IsEmpty)
            {
              sum += buffer.Read();
            }

            Result = sum;
        }


        public void ProcessStrings(IEnumerable<string> strings)
        {
            Strings = strings;
        }

    }
}
