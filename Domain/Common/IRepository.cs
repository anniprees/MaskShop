namespace MaskShop.Domain.Common
{
    public interface IRepository<T> : ICrudMethods<T>, IRepository, ISorting, IFiltering, IPaging
    {

    }

    public interface IRepository
    {
        object GetById(string id);
    }
}
