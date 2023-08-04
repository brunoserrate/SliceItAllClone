using System.Text;
using UnityEngine;
using TMPro;

namespace SerrateDevs.SliceItAllClone {
    public class LevelDisplayUI : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI _levelText;
        private int _currentLevelIndex = 0;
        private StringBuilder _stringBuilder = new StringBuilder();

        private void Awake() {
            _stringBuilder.Append("Level ");

            _levelText.text = _stringBuilder.ToString();
        }

        public void SetLevelText() {
            _stringBuilder.Clear();
            _stringBuilder.Append("Level ");
            _stringBuilder.Append(_currentLevelIndex + 1);

            _levelText.text = _stringBuilder.ToString();
        }

        public void SetCurrentLevelIndex(int levelIndex) {
            _currentLevelIndex = levelIndex;
        }
    }
}
