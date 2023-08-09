using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.UI.Panels
{
    public class AlwaysOnPanel : Panel
    {
        [SerializeField] private TMP_Text _counter;
        [SerializeField] private TMP_Text _bestScore;

        private IPointsCounter _pointsCounter;
        private IPlayerProgressHandler _playerProgressHandler;

        [Inject]
        public void Construct(IPointsCounter pointsCounter, IPlayerProgressHandler playerProgressHandler)
        {
            _pointsCounter = pointsCounter;
            _playerProgressHandler = playerProgressHandler;
        }

        private void Awake()
        {
            _bestScore.gameObject.SetActive(_playerProgressHandler.PlayerProgress.Progeress.Value != 0);

            DispalyValueOn(_bestScore, _playerProgressHandler.PlayerProgress.Progeress.Value);

            _playerProgressHandler.PlayerProgress.Progeress.Subscribe((value) => DispalyValueOn(_bestScore, value));
            _pointsCounter.Score.Subscribe((value) => DispalyValueOn(_counter, value));
        }

        private void DispalyValueOn(TMP_Text textField, int value) =>
            textField.text = value.ToString("00000");
    }
}
