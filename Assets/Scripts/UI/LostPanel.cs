using UnityEngine;
using UnityEngine.UI;

public class LostPanel : MonoBehaviour
{
    [SerializeField, HideInInspector] private Button _restart;

    private void Awake()
    {
        GameManager.OnLost += Activate;
        _restart.onClick.AddListener(GameManager.Restart);

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.OnLost -= Activate;
        _restart.onClick.RemoveListener(GameManager.Restart);
    }

    private void Activate()
    {
        gameObject.SetActive(true);
    }

    private void OnValidate()
    {
        if (_restart == null) _restart = GetComponentInChildren<Button>();
    }
}
