using UnityEngine;

namespace Gameplay.Interfaces
{
    public interface IObjectPool<T> where T : Object
    {
        public void PoolObject(T objectToPool);

        public T GetObstacle();
    }
}