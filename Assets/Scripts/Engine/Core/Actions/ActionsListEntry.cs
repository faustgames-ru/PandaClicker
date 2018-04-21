using System;
using Engine.Core.Asyncs;

namespace Engine.Core.Actions
{
    public class ActionsListEntry<T>: IActionEntry
    {
        private T _args;
        private Action<T> _action;
        private AsyncState _state;

        public ActionsListEntry(Action<T> action, T args)
        {
            _action = action;
            _args = args;
            _state = new AsyncState();
        }

        public AsyncState State => _state;

        public void Invoke()
        {
            _action?.Invoke(_args);
            AsyncState.Compleate(_state);
        }
    }
}
