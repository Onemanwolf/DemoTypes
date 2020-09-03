using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DemoTypes
{
    public class Repo<T> : IRepo<T>
    {

        public List<T> _reposistory { get; set; }

        public Repo()
        {
            _reposistory = new List<T>();
        }

        public async Task Save(T value)
        {
            var result = _reposistory.Select(x => x.Equals(value));

            _reposistory.Add(value);


        }

        public async Task Delete(T value)
        {
            _reposistory.Remove(value);


        }






    }
}
