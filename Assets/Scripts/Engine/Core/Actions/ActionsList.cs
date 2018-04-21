using System;
using System.Collections.Generic;
using Engine.Core.Asyncs;

namespace Engine.Core.Actions
{
    public class ActionsList
    {
        private List<IActionEntry> _invokeList = new List<IActionEntry>();
        private List<IActionEntry> _entries = new List<IActionEntry>();
        private AsyncSheduler _sheduler;

        public ActionsList(AsyncSheduler sheduler)
        {
            _sheduler = sheduler;
        }

        public AsyncState<TResult> Add<TArgs, TResult>(Func<TArgs, TResult> action, TArgs args)
        {
            var entry = new ActionsListEntry<TArgs, TResult>(action, args, _sheduler);
            _entries.Add(entry);
            return entry.State;
        }

        public void Invoke()
        {
            foreach (var entry in _entries)
            {
                _invokeList.Add(entry);
            }
            _entries.Clear();
            foreach (var entry in _invokeList)
            {
                entry?.Invoke();
            }
            _invokeList.Clear();
        }
    }
}
