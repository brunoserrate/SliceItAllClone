using System;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class ScoreController : MonoBehaviour {
        public static Action<int> OnScoreChange;
        public static Action<int> OnFinalCurrentScoreChange;

        private int _totalScore;
        private int _currentScore;

        #region EnableDisable
        private void OnEnable() {
            Sliceable.OnSliceableDestroyed += OnPlayerGainScore;
            FinishGoal.OnPlayerWin += OnPlayerWin;
        }

        private void OnDisable() {
            Sliceable.OnSliceableDestroyed -= OnPlayerGainScore;
            FinishGoal.OnPlayerWin -= OnPlayerWin;
        }
        #endregion
        #region Events
        private void OnPlayerGainScore(int value) {
            _currentScore += value;
            _totalScore += value;
            OnScoreChange?.Invoke(_totalScore);
        }

        private void OnPlayerWin(float scoreMultiplier) {
            int finalScore = (int)(_currentScore * scoreMultiplier);

            _totalScore += finalScore;
            OnScoreChange?.Invoke(_totalScore);

            OnFinalCurrentScoreChange?.Invoke(finalScore);
        }
        #endregion
    }
}
