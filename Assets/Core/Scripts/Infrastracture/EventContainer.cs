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

        public void Clear() =>
            _eventCallbacks.Clear();

        public void ExecuteEvent(Action<T> action) =>
            _eventCallbacks.ForEach((T callback) => action(callback));
    }
}