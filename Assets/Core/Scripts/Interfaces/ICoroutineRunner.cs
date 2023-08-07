using System.Collections;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
