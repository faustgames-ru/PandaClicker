using System;
using Engine.Core.Asyncs;

namespace Engine.Core.Actions
{
    public class ActionsListEntry<TArgs, TResult> : IActionEntry
    {
        private TArgs _args;
        private Func<TArgs, TResult> _action;
        private AsyncState<TResult> _state;

        public ActionsListEntry(Func<TArgs, TResult> action, TArgs args, AsyncSheduler sheduler)
        {
            _action = action;
            _args = args;
            _state = new AsyncState<TResult>(sheduler);
        }

        public AsyncState<TResult> State => _state;

        public void Invoke()
        {
            var result = default(TResult);
            if (_action != null)
            {
                result = _action.Invoke(_args);
            }
            _state.Compleate(result);
        }
    }
}
