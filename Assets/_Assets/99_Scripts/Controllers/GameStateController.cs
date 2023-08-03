using System;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class GameStateController : MonoBehaviour {

        public static GameStateController Instance { get; private set; }

        public static Action<GameStates> OnGameStateChange;

        private GameStates _currentGameState;
        public GameStates CurrentGameState => _currentGameState;

        #region Singleton
        private void Awake() {
            if(Instance == null) {
                Instance = this;
            } else {
                Destroy(gameObject);
            }
        }
        #endregion

        #region EnableDisable
        private void OnEnable() {
            PlayerController.OnTap += OnPlayerTap;
            DeathZone.OnPlayerLose += OnPlayerLose;
            FinishGoal.OnPlayerWin += OnPlayerWin;
            LevelController.OnLevelLoaded += ResetState;
        }

        private void OnDisable() {
            PlayerController.OnTap -= OnPlayerTap;
            DeathZone.OnPlayerLose -= OnPlayerLose;
            FinishGoal.OnPlayerWin -= OnPlayerWin;
            LevelController.OnLevelLoaded -= ResetState;
        }
        #endregion

        #region Events
        private void OnPlayerTap() {
            if(_currentGameState != GameStates.Start) return;

            ChangeGameState(GameStates.InGame);
        }
        private void OnPlayerLose() {
            ChangeGameState(GameStates.Lose);
        }

        private void OnPlayerWin(float scoreMultiplier) {
            ChangeGameState(GameStates.Win);
        }

        private void ResetState(int levelIndex) {
            ChangeGameState(GameStates.Start);
        }
        #endregion

        private void ChangeGameState(GameStates newGameState) {
            if(_currentGameState == newGameState) return;

            _currentGameState = newGameState;
            OnGameStateChange?.Invoke(_currentGameState);
        }


    }
}
