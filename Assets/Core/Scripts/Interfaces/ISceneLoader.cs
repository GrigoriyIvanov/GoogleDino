using System;

namespace Core.Interfaces
{
    public interface ISceneLoader
    {
        public void Load(string sceneName, Action onLoaded = null);
    }
}