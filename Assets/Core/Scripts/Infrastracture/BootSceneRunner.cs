using Core;
using UnityEngine;
using Zenject;

public class BootSceneRunner : MonoBehaviour
{
    private IGameManager _gameManager;

    [Inject]
    public void Constructor(IGameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void Awake() => _gameManager.StartPlay();
}
