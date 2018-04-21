using System;

namespace Engine.Core.Asyncs
{
    public class AsyncState : AsyncState<Void>
    {
        public AsyncState(AsyncSheduler sheduler): base(sheduler)
        {
        }

        public void Compleate()
        {
            Compleate(Void.Empty);
        }
    }

    public class AsyncState<T> : IAsyncAwaiter<T>
    {
        private bool _compleated;
        private T _result;
        private Action _continuation;
        private AsyncSheduler _sheduler;

        public AsyncState(AsyncSheduler sheduler)
        {
            _sheduler = sheduler;
        }

        public void Compleate(T result)
        {
            _result = result;
            _compleated = true;
            _sheduler.Shedule(_continuation);
            _continuation = null;
        }

        public bool IsCompleted => _compleated;

        public IAsyncAwaiter<T> GetAwaiter()
        {
            return this;
        }
        
        public T GetResult()
        {
            return _result;
        }

        public void OnCompleted(Action continuation)
        {
            _continuation = continuation;
        }
    }
}
