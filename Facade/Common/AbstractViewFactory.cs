using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Common;
using MaskShop.Domain.Common;

namespace MaskShop.Facade.Common
{
    public abstract class AbstractViewFactory<TData, TObject, TView>
        where TData : PeriodData, new()
        where TView : PeriodView, new()
        where TObject : IEntity<TData>
    {
        public virtual TObject Create(TView v)
        {
            var d = new TData();
            CopyMembers(v, d);
            return ToObject(d);
        }

        internal protected abstract TObject ToObject(TData d);

        internal protected virtual void CopyMembers(TView v, TData d) => Copy.Members(v, d);

        internal protected virtual void CopyMembers(TData d, TView v) => Copy.Members(d, v);

        public virtual TView Create(TObject o)
        {
            var v = new TView();
            CopyMembers(o.Data, v);
            return v;
        }
    }
}
