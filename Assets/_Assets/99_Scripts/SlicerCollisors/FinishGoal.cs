using System;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class FinishGoal : MonoBehaviour, ISlicerCollisor
    {
        public static event Action<float> OnPlayerWin;

        [SerializeField] private float _scoreMultiplier = 1f;
        [SerializeField] private TMPro.TextMeshProUGUI _scoreText;

        private void Start() {
            if(_scoreText != null)
                _scoreText.text = $"X{_scoreMultiplier.ToString()}";
        }

        public void OnSlicerHandleHit(PlayerController playerController) {
            playerController.JumpBack();
        }

        public void OnSlicerSharpEdgeHit(PlayerController playerController) {
            if(GameStateController.Instance.CurrentGameState != GameStates.InGame) return;

            PlayerWin(playerController);
        }

        private void PlayerWin(PlayerController playerController) {
            playerController.Stuck();

            OnPlayerWin?.Invoke(_scoreMultiplier);
        }
    }
}
