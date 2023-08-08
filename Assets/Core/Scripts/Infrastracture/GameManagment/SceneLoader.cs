using Core.Interfaces;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core.Inftastracture.GameManagment
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        [Inject]
        public SceneLoader(ICoroutineRunner coroutineRunner) =>
             _coroutineRunner = coroutineRunner;

        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

        private IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            //if (SceneManager.GetActiveScene().name == name)
            //{
            //    onLoaded?.Invoke();
            //    yield break;
            //}

            AsyncOperation nextSceneLoading = SceneManager.LoadSceneAsync(name);

            while (!nextSceneLoading.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}
