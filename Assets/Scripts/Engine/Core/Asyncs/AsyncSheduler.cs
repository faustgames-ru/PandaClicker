using System;
using System.Collections.Generic;

namespace Engine.Core.Asyncs
{
    public class AsyncSheduler
    {
        private List<Action> _invokes = new List<Action>();
        private List<Action> _actions = new List<Action>();

        public void Shedule(Action continuation)
        {
            _actions.Add(continuation);
        }

        public void Invoke()
        {
            foreach (var action in _actions)
            {
                _invokes.Add(action);
            }
            _actions.Clear();
            foreach (var action in _invokes)
            {
                action();
            }
        }
    }
}
