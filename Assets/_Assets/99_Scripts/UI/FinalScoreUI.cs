using UnityEngine;
using TMPro;

namespace SerrateDevs.SliceItAllClone {
    public class FinalScoreUI : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI _scoreText;
        private void OnEnable() {
            ScoreController.OnFinalCurrentScoreChange += OnScoreChange;
        }

        private void OnDisable() {
            ScoreController.OnFinalCurrentScoreChange -= OnScoreChange;
        }

        private void OnScoreChange(int score) {
            _scoreText.text = score.ToString();
        }
    }
}
