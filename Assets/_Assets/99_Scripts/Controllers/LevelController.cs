using System;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class LevelController : MonoBehaviour {

        public static Action<int> OnLevelLoaded;

        [SerializeField] private GameObject[] _levelPrefabs;

        private int _currentLevelIndex = 0;
        private GameObject _currentLevelPrefab;

        private void OnEnable() {
            RestartLevelUI.OnRestartLevel += ResetLevel;
            NextLevelUI.OnNextLevel += NextLevel;
        }

        private void OnDisable() {
            RestartLevelUI.OnRestartLevel -= ResetLevel;
            NextLevelUI.OnNextLevel -= NextLevel;
        }

        private void Start() {
            LoadLevel();
        }

        public void NextLevel() {
            _currentLevelIndex++;
            LoadLevel();
        }

        public void ResetLevel() {
            LoadLevel();
        }

        private void LoadLevel() {
            if (_currentLevelPrefab != null) {
                Destroy(_currentLevelPrefab);
            }

            int levelToLoad = Math.Clamp(_currentLevelIndex, 0, _levelPrefabs.Length - 1);

            _currentLevelPrefab = Instantiate(_levelPrefabs[levelToLoad], transform);
            OnLevelLoaded?.Invoke(levelToLoad);
        }
    }
}
