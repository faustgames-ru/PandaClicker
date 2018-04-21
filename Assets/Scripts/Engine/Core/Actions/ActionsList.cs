using System;
using System.Collections.Generic;
using Engine.Core.Asyncs;

namespace Engine.Core.Actions
{
    public class ActionsList
    {
        public AsyncState Add<T>(Action<T> action, T args)
        {
            var entry = new ActionsListEntry<T>(action, args);
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

        List<IActionEntry> _invokeList = new List<IActionEntry>();
        List<IActionEntry> _entries = new List<IActionEntry>();
    }
}
