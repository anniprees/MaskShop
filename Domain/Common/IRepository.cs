namespace MaskShop.Domain.Common
{
    public interface IRepository<T> : ICrudMethods<T>, IRepository
    {

    }

    public interface IRepository
    {
        object GetById(string id);
    }
}
