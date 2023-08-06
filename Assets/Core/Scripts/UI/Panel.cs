using Core.Interfaces;
using UnityEngine;

namespace Core.UI
{
    public abstract class Panel : MonoBehaviour, IPanel
    {
        public void Show()
        {
            if (gameObject.activeInHierarchy)
            {
                Debug.LogWarning("Attemp to show panel which is already active.");
                return;
            }

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            if (!gameObject.activeInHierarchy)
            {
                Debug.LogWarning("Attemp to hide panel which is already inactive.");
                return;
            }

            gameObject.SetActive(false);
        }

        public void ChangeVisibility() =>
            gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}