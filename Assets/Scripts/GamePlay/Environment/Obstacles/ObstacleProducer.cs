using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Environment
{
    public class ObstacleProducer : MonoBehaviour
    {
        [SerializeField] private Ground _ground;

        [SerializeField] private List<GameObject> _obstacles;

        [SerializeField] private float _spawningTime = 1.5f;
        [SerializeField] private float _xBorder;

        private ObstaclePool _obstaclePool;
        private List<GameObject> _activeObstacles;

        private Vector3 _spawnPosition;

        private void Awake()
        {
            _obstaclePool = new ObstaclePool(_obstacles);

            _spawnPosition = Vector3.zero;

            _activeObstacles = new List<GameObject>();

            _spawnPosition = new Vector3(30, 0, 0);

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
        }

        private void ProduceObstacle()
        {
            Transform platformToSpawnOn = _ground.UnitToSpawnOn;

            Transform obstacle = _obstaclePool.GetObstacle();

            if (obstacle == null)
                return;

            obstacle.position = _spawnPosition + new Vector3(Random.Range(0, 5), 0, 0);
            obstacle.parent = platformToSpawnOn;

            _activeObstacles.Add(obstacle.gameObject);
        }

        private IEnumerator SpawnCycle()
        {
            yield return new WaitForSecondsRealtime(_spawningTime);

            ProduceObstacle();

            StartCoroutine(SpawnCycle());
        }
    }
}