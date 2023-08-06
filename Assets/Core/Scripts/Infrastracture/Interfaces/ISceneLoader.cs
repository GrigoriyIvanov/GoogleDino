using System;
using UnityEngine.SceneManagement;

public interface ISceneLoader
{
    public void Load(Scene scene, Action onLoaded);
}