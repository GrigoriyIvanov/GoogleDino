using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) =>
        _coroutineRunner = coroutineRunner;

    private void Load(string name, Action onLoaded = null) =>
        _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

    private IEnumerator LoadScene(string name, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().name == name)
        {
            onLoaded?.Invoke();
            yield break;
        }

        AsyncOperation nextSceneLoading = SceneManager.LoadSceneAsync(name);

        while (!nextSceneLoading.isDone)
            yield return null;

        onLoaded?.Invoke();
    }
}
