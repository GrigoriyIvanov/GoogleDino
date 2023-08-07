using Core.Interfaces;
using UnityEngine;

namespace Core.Inftastracture
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void Awake() => 
            DontDestroyOnLoad(this);
    }
}