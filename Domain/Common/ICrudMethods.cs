using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaskShop.Domain.Common
{
    public interface ICrudMethods<T>
    {
        Task<List<T>> Get();

        Task<T> Get(string id);

        Task Delete (string id);

        Task<T> Add(T obj);

        Task<T> Update (T obj);

    }
}
