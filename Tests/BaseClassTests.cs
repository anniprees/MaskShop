using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using MaskShop.Aids;
using MaskShop.Data.Common;
using MaskShop.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests
{
    public abstract class BaseClassTests<TClass, TBaseClass> : BaseTests
    {
        protected TClass obj;

        [TestInitialize] public virtual void TestInitialize() => Type = typeof(TClass);

        [TestCleanup]
        public virtual void TestCleanup()
        {
            Type = null;
            obj = default;
        }

        [TestMethod]
        public void IsInheritedTest()
            => Assert.AreEqual(GetBaseClass(), Type.BaseType);

        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);


        protected virtual Type GetBaseClass() => typeof(TBaseClass);

        protected static void IsNullableProperty<T>(Func<T> get, Action<T> set)
        {
            IsProperty(get, set);
            set(default);
            Assert.IsNull(get());
        }

        protected static void IsProperty<T>(Func<T> get, Action<T> set)
        {
            var d = (T)GetRandom.Value(typeof(T));

            while (true)
            {
                if (!d.Equals(get())) break;
                d = (T)GetRandom.Value(typeof(T));
            }

            Assert.AreNotEqual(d, get());
            set(d);
            Assert.AreEqual(d, get());
        }

        protected static void IsProperty(Func<bool> get, Action<bool> set)
        {
            var d = !get();
            Assert.AreNotEqual(d, get());
            set(d);
            Assert.AreEqual(d, get());
        }

        protected static void IsNullableProperty(object o, string name, Type t)
        {
            IsProperty(o, name, t);
            var p = o.GetType().GetProperty(name);
            CanSetValue(o, p, null);
        }

        protected static void IsProperty(object o, string name, Type t)
        {
            var p = IsReadWriteProperty(o, name, t);
            CanSetValue(o, p, GetRandom.Value(t));
        }
        private static void CanSetValue(object o, PropertyInfo p, object v)
        {
            p.SetValue(o, v);
            Assert.AreEqual(v, p.GetValue(o));
        }
        protected static PropertyInfo IsReadWriteProperty(object o, string name, Type t)
        {
            var p = o.GetType().GetProperty(name);
            Assert.IsNotNull(p);
            Assert.AreEqual(t, p.PropertyType);
            Assert.IsTrue(p.CanWrite);
            Assert.IsTrue(p.CanRead);

            return p;
        }
        protected static void HasDisplayName(string propertyName, string displayName)
            => Assert.AreEqual(displayName, GetMember.DisplayName<TClass>(propertyName));

        protected void IsProperty<TType>(string propertyName, string displayName)
        {
            IsProperty(obj, propertyName, typeof(TType));
            HasDisplayName(propertyName, displayName);
        }

        protected void IsNullableProperty<TType>(string propertyName, string displayName)
        {
            IsNullableProperty(obj, propertyName, typeof(TType));
            HasDisplayName(propertyName, displayName);
        }

        protected void IsProperty<TType>()
        {
            var n = GetPropertyName();
            IsProperty(obj, n, typeof(TType));
        }

        protected string GetPropertyName(int stackFrameIdx = 2)
        {
            var stack = new StackTrace();
            var n = stack.GetFrame(stackFrameIdx)?.GetMethod()?.Name;

            return n?.Replace("Test", string.Empty);
        }

        protected void IsNullableProperty<TType>()
        {
            var n = GetPropertyName();
            IsNullableProperty(obj, n, typeof(TType));
        }

        protected void IsProperty<TType>(string displayName)
        {
            var n = GetPropertyName();
            IsProperty(obj, n, typeof(TType));
            HasDisplayName(n, displayName);
        }

        protected void IsNullableProperty<TType>(string displayName)
        {
            var n = GetPropertyName();
            IsNullableProperty(obj, n, typeof(TType));
            HasDisplayName(n, displayName);
        }

        protected void IsReadOnlyProperty(object expected)
        {
            var n = GetPropertyNameAfter("IsReadOnlyProperty");
            IsReadOnlyProperty(obj, n, expected);
        }

        protected void IsReadOnlyProperty()
        {
            var n = GetPropertyNameAfter("IsReadOnlyProperty");
            IsReadOnlyProperty(obj, n);
        }
        protected static void IsReadOnlyProperty(object o, string name, object expected)
        {
            var actual = IsReadOnlyProperty(o, name);
            Assert.AreEqual(expected, actual);
        }

        protected static object IsReadOnlyProperty(object o, string name)
        {
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.IsFalse(property.CanWrite);
            Assert.IsTrue(property.CanRead);

            return property.GetValue(o);
        }

        protected void GetListFromRepository<TDetail, TData, TRepository>(
            Action<TData> setId, Func<TData, TDetail> toObject) where TRepository : IRepository<TDetail>
        {
            var n = GetPropertyNameAfter("GetListFromRepository");
            GetListFromRepository<TDetail, TData, TRepository>(obj, n, setId, toObject);
        }

        protected string GetPropertyNameAfter(string methodName)
        {
            var stack = new StackTrace();
            int i;
            for (i = 0; i < stack.FrameCount - 1; i++)
            {
                var n = stack.GetFrame(i)?.GetMethod()?.Name;

                if (n == methodName) break;
            }

            for (i += 1; i < stack.FrameCount - 1; i++)
            {
                var n = stack.GetFrame(i)?.GetMethod()?.Name;

                if (n == "MoveNext" || n == "Start") continue;

                return n?.Replace("Test", string.Empty);
            }

            return string.Empty;
        }

        protected void GetListFromRepository<TDetail, TData, TRepository>(
            object obj, string name, Action<TData> setId, Func<TData, TDetail> toObject)

            where TRepository : IRepository<TDetail>
        {

            var t = IsReadOnlyProperty(obj, name) as IReadOnlyList<TDetail>;
            Assert.IsNotNull(t);
            Assert.AreEqual(0, t.Count);
            var values = GetRepository.Instance<TRepository>();
            var valuesCount = GetRandom.UInt8(10, 20);

            for (var i = 0; i < valuesCount; i++)
            {
                var d = GetRandom.Object<TData>();
                if (i % 4 == 0) setId(d);
                values.Add(toObject(d)).GetAwaiter();
            }

            t = IsReadOnlyProperty(obj, name) as IReadOnlyList<TDetail>;
            Assert.AreEqual((int)Math.Ceiling(valuesCount / 4.0), t?.Count);
        }

        protected void GetFromRepository<TData, TObject, TRepository>(string id, Func<TData> getData,
            Func<TData, TObject> toObject)

            where TData : UniqueEntityData, new()
            where TObject : IUniqueEntity<TData>
            where TRepository : IRepository<TObject>
        {
            var d = GetRandom.Object<TData>();
            GetRepository.Instance<TRepository>().Add(toObject(d)).GetAwaiter();
            Assert.IsNotNull(getData());
            TestArePropertiesEqual(getData(), new TData(), "Id");
            d.Id = id;
            GetRepository.Instance<TRepository>().Add(toObject(d)).GetAwaiter();
            TestArePropertiesEqual(d, getData());
        }

        protected void GetFromRepository<TData, TObject, TRepository>(
            TData d, Func<TData> getData, Func<TData, TObject> toObject)

            where TData : PeriodData, new()
            where TObject : IEntity<TData>
            where TRepository : IRepository<TObject>
        {
            GetRepository.Instance<TRepository>().Add(toObject(d)).GetAwaiter();
            TestArePropertiesEqual(d, getData());
        }

    }
}
