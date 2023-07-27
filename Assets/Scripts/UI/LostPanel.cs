using UnityEngine;
using UnityEngine.UI;

public class LostPanel : MonoBehaviour
{
    [SerializeField, HideInInspector] private Button _restart;

    private void Awake()
    {
        GameManager.OnLost += () => gameObject.SetActive(true);
        gameObject.SetActive(false);
    }


    private void OnEnable() => _restart.onClick.AddListener(GameManager.Restart);

    private void OnDisable() => _restart.onClick.RemoveListener(GameManager.Restart);

    private void OnValidate()
    {
        if (_restart == null) _restart = GetComponentInChildren<Button>();
    }
}
