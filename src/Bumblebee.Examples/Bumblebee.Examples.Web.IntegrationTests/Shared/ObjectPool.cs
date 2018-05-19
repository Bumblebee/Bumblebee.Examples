using System;
using System.Collections.Concurrent;

namespace Bumblebee.Examples.Web.IntegrationTests.Shared
{
    public class ObjectPool<T> : IDisposable where T : IDisposable, IValidatable
    {
        private readonly ConcurrentQueue<T> _objects;
        private readonly Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            _objects = new ConcurrentQueue<T>();
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
        }

        public T GetObject()
        {
            var exists = _objects.TryDequeue(out var item);

            if (exists && item.IsValid())
            {
                return item;
            }

            if (exists)
            {
                item.Dispose();
            }

            return _objectGenerator();
        }

        public void PutObject(T item)
        {
            if (item.IsValid())
            {
                _objects.Enqueue(item);
            }
            else
            {
                item.Dispose();
            }
        }

        public void Dispose()
        {
            foreach (var item in _objects)
            {
                item.Dispose();
            }
        }
    }

    public interface IValidatable
    {
        bool IsValid();
    }
}
