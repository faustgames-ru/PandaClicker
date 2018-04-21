using System;
using System.Runtime.CompilerServices;

namespace Engine.Core.Asyncs
{
    public class AsyncStateAwaiter<T> : INotifyCompletion
    {
        public void OnCompleted(Action continuation)
        {
        }

        bool IsCompleted { get; }

        T GetResult()
        {
            return default(T);
        }
    }

    public class AsyncState
    {
        bool _compleated;

        public bool Compleated;

        public void Compleate()
        {
            _compleated = true;
        }

        public object GetAwaiter()
        {
            // todo: implement awaiter
            return null;
        }

        internal static void Compleate(AsyncState state)
        {
            var stateRef = state;
            stateRef?.Compleate();
            state = null;
        }
    }

    public class AsyncSheduler
    {
    }

}
