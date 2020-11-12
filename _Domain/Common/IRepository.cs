using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Domain.Common
{
    public interface IRepository<T> : ICrudMethods<T>, ISorting, IFiltering, IPaging, IRepository
    {

    }

    public interface IRepository
    {
        object GetById(string id);
    }
}
