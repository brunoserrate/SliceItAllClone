using System;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class ScoreController : MonoBehaviour {
        public static Action<int> OnScoreChange;

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
            OnScoreChange?.Invoke(_currentScore);
        }

        private void OnPlayerWin(float scoreMultiplier) {
            _totalScore += (int)(scoreMultiplier * _currentScore);
            OnScoreChange?.Invoke(_totalScore);
        }
        #endregion
    }
}
