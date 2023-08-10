using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Environment
{
    public class ObstaclePool : IObjectPool<Transform>
    {
        private List<Transform> _poolOfObjects;

        public ObstaclePool(List<Transform> poledObjects)
        {
            _poolOfObjects = new List<Transform>();
            for (int i = 0; i < poledObjects.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Transform tmp = Object.Instantiate(poledObjects[i].gameObject).transform;
                    tmp.gameObject.SetActive(false);

                    _poolOfObjects.Add(tmp);
                }
            }
        }

        public Transform GetObstacle()
        {
            if (_poolOfObjects.Count == 0)
                return null;

            int pointer = Random.Range(0, _poolOfObjects.Count);

            Transform pooledObject = _poolOfObjects[pointer].transform;
            pooledObject.gameObject.SetActive(true);

            _poolOfObjects.RemoveAt(pointer);

            return pooledObject;
        }

        public void PoolObject(Transform objectToPool)
        {
            //objectToPool.transform.parent = null;
            objectToPool.gameObject.SetActive(false);
            _poolOfObjects.Add(objectToPool);
        }
    }
}