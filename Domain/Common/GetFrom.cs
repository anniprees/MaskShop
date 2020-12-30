using System.Collections.Generic;
using MaskShop.Aids;

namespace MaskShop.Domain.Common
{
    public sealed class GetFrom<TRepository, TObject>
        where TRepository : IRepository<TObject>
    {
        internal TRepository Repository
            => GetRepository.Instance<TRepository>();

        public TObject ById(string id)
            => Safe.Run(() => Repository.Get(id).GetAwaiter().GetResult(), default(TObject));

        public IReadOnlyList<TObject> ListBy(string field, string value)
        {
            var r = Repository;

            return List(r, field, value);
        }
        public IReadOnlyList<TObject> ListBy(string field, string value, string searchString)
        {
            var r = Repository;
            r.SearchString = searchString;
            return List(r, field, value);
        }

        private static IReadOnlyList<TObject> List(TRepository r, string field, string value)
        {
            r.FixedFilter = field;
            r.FixedValue = value;
            r.PageIndex = -1;
            return r.Get().GetAwaiter().GetResult();
        }
    }
}

