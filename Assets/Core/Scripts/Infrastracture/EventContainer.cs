using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.Inftastracture
{
    public class EventContainer<T> : IEventContainer<T> where T : class
    {
        private List<T> _eventCallbacks = new List<T>();

        public void AddCallback(T callBack) =>
            _eventCallbacks.Add(callBack);

        public void Clear()
        {
            for (int i = 0; i < _eventCallbacks.Count; i++)
            {
                if (_eventCallbacks[i].Equals(null))
                    _eventCallbacks.RemoveAt(i);
            }
        }

        public void ExecuteEvent(Action<T> action) =>
            _eventCallbacks.ForEach((T callback) => action(callback));
    }
}