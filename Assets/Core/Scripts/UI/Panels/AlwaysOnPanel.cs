using TMPro;
using UnityEngine;
using Zenject;

namespace Core.UI.Panels
{
    public class AlwaysOnPanel : Panel
    {
        [SerializeField] private TMP_Text _counter;
        [SerializeField] private TMP_Text _bestScore;

        private IPointsCounter _pointsCounter;

        [Inject]
        public void Construct(IPointsCounter pointsCounter) =>
            _pointsCounter = pointsCounter;

        private void FixedUpdate() =>
            _counter.text = _pointsCounter.Score.ToString("00000");
    }
}
