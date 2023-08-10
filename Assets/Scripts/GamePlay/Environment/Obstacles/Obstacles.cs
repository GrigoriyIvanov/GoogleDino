using Gameplay.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Environment.Obstacles
{
    public class Obstacles : MonoBehaviour
    {
        [SerializeField] private float _spawningTime = 1.5f;
        [SerializeField] private float _xBorder = -24;
        [SerializeField] private Transform _spawnPoint;

        private List<Transform> _activeObstacles;
        
        private IHorizontalMovement _movement;
        private IObjectPool<Transform> _obstaclePool;

        [Inject]
        public void Constructor(IHorizontalMovement movement, IObjectPool<Transform> objectPool)
        {
            _movement = movement;
            _obstaclePool = objectPool;
        }

        private void Awake()
        {
            _activeObstacles = new List<Transform>();

            StartCoroutine(SpawnCycle());
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _activeObstacles.Count; i++)
            {
                if (_activeObstacles[i].transform.position.x < _xBorder)
                {
                    _obstaclePool.PoolObject(_activeObstacles[i]);
                    _activeObstacles.RemoveAt(i);
                }
            }

            _movement.Move(_activeObstacles);
        }

        private void ProduceObstacle()
        {
            Transform obstacle = _obstaclePool.GetObstacle();

            if (obstacle == null)
                return;

            obstacle.position = _spawnPoint.position + new Vector3(Random.Range(-2f, 2f), 0, 0);
            obstacle.parent = transform;

            _activeObstacles.Add(obstacle);
        }

        private IEnumerator SpawnCycle()
        {
            yield return new WaitForSecondsRealtime(_spawningTime);

            ProduceObstacle();

            StartCoroutine(SpawnCycle());
        }
    }
}