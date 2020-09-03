using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoTypes
{
    public interface IRepo<T>
    {
        List<T> _reposistory { get; set; }

        Task Delete(T value);
        Task Save(T value);
    }
}