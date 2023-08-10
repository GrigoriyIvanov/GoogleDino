using Gameplay.Interfaces;
using Gameplay.Player;
using System.Collections;
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

        [SerializeField] private float _flickingPeriod = 0.35f;
        [SerializeField] private int _flickCount = 4;

        private IPointsCounter _pointsCounter;
        private IPlayerProgressHandler _playerProgressHandler;

        private GameSounds _gameSounds;

        private Coroutine _flicking;
        private int _flickCounter;

        [Inject]
        public void Construct(IPointsCounter pointsCounter, IPlayerProgressHandler playerProgressHandler, GameSounds gameSounds)
        {
            _pointsCounter = pointsCounter;
            _playerProgressHandler = playerProgressHandler;
            _gameSounds = gameSounds;
        }

        private void Awake()
        {
            _bestScore.gameObject.SetActive(_playerProgressHandler.PlayerProgress.Progeress.Value != 0);

            DispalyValueOn(_bestScore, _playerProgressHandler.PlayerProgress.Progeress.Value);

            _playerProgressHandler.PlayerProgress.Progeress.Subscribe((value) => DispalyValueOn(_bestScore, value));
            _pointsCounter.Score.Subscribe(
                (value) =>
                {
                    if (_flicking != null)
                        return;

                    DispalyValueOn(_counter, value);

                    if (value > 0 && value % 100 == 0)
                    {
                        _gameSounds.PlayScoreUpdateSound();
                        _flicking = StartCoroutine(Flick());
                    }
                });

        }

        private IEnumerator Flick()
        {
            yield return new WaitForSecondsRealtime(_flickingPeriod);
            _counter.gameObject.SetActive(!_counter.gameObject.activeSelf);

            _flickCounter++;

            if (_flickCounter < _flickCount)
                StartCoroutine(Flick());
            else
            {
                _flickCounter = 0;
                StopAllCoroutines();
                _flicking = null;
            }
        }

        private void DispalyValueOn(TMP_Text textField, int value) =>
            textField.text = value.ToString("00000");
    }
}
