using System;

namespace Core.Interfaces
{
    public interface IEventContainer<T> where T : class
    {
        public void AddCallback(T callBack);

        public void Clear();

        public void ExecuteEvent(Action<T> action);
    }
}