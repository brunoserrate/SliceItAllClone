using System.Text;
using UnityEngine;
using TMPro;

namespace SerrateDevs.SliceItAllClone {
    public class LevelDisplayUI : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI _levelText;
        private StringBuilder _stringBuilder = new StringBuilder();

        private void Awake() {
            _stringBuilder.Append("Level ");

            _levelText.text = _stringBuilder.ToString();
        }

        private void OnEnable() {
            LevelController.OnLevelLoaded += OnLevelLoaded;
        }

        private void OnDisable() {
            LevelController.OnLevelLoaded -= OnLevelLoaded;
        }

        private void OnLevelLoaded(int levelIndex) {
            _stringBuilder.Clear();
            _stringBuilder.Append("Level ");
            _stringBuilder.Append(levelIndex + 1);

            _levelText.text = _stringBuilder.ToString();
        }
    }
}
