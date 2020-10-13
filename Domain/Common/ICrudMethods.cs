using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaskShop.Domain.Common
{
    public interface ICrudMethods<T>
    {
        Task<List<T>> Get();

        Task<T> Get(string id);

        Task Delete (string id);

        Task Add(T obj);

        Task Update (T obj);

    }
}
