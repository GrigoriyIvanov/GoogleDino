using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Environment
{
    public class ObstaclePool
    {
        [SerializeField] private List<GameObject> _poolOfObjects;

        public ObstaclePool(List<GameObject> poledObjects)
        {
            _poolOfObjects = new List<GameObject>();
            for (int i = 0; i < poledObjects.Count; i++)
            {
                GameObject tmp = Object.Instantiate(poledObjects[i]);
                tmp.SetActive(false);

                _poolOfObjects.Add(tmp);
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

        public void PoolObject(GameObject objectToPool)
        {
            objectToPool.transform.parent = null;
            objectToPool.SetActive(false);
            _poolOfObjects.Add(objectToPool);
        }
    }
}