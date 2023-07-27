using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnLost;

    public static void Restart() => SceneManager.LoadScene(0);

    public static void MakeLost() => OnLost?.Invoke();
}
