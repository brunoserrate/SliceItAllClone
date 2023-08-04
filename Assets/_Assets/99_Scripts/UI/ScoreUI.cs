using System.Text;
using UnityEngine;
using TMPro;

namespace SerrateDevs.SliceItAllClone {
    public class ScoreUI : MonoBehaviour {
        [Header("Score UI Components")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        private StringBuilder _scoreStringBuilder = new StringBuilder();

        private void Awake() {
            _scoreStringBuilder.Append("0");
            _scoreText.text = _scoreStringBuilder.ToString();
        }

        #region EnableDisable
        private void OnEnable() {
            ScoreController.OnScoreChange += OnScoreChange;
        }

        private void OnDisable() {
            ScoreController.OnScoreChange -= OnScoreChange;
        }
        #endregion

        #region Events
        private void OnScoreChange(int score) {
            _scoreStringBuilder.Clear();
            _scoreStringBuilder.Append(score.ToString());

            _scoreText.text =  _scoreStringBuilder.ToString();
        }
        #endregion

    }
}
