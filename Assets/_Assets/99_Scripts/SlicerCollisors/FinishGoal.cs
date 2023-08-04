using System;
using System.Collections;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class FinishGoal : MonoBehaviour, ISlicerCollisor
    {
        public static event Action<float> OnPlayerWin;

        [Header("Components")]
        [Tooltip("The score text to show the score multiplier")]
        [SerializeField] private TMPro.TextMeshProUGUI _scoreText;

        [Header("Settings")]
        [Tooltip("The score multiplier when the player wins")]
        [SerializeField] private float _scoreMultiplier = 1f;

        [Space(2)]

        [Tooltip("The time to wait to the player win after it hits the finish goal")]
        [SerializeField] private float _delayToWin = 0.5f;

        // <summary>
        // The time to wait to the player win after it hits the finish goal. The variable prevents to put more work on the garbage collector
        // </summary>
        private WaitForSeconds _delayToWinWaitForSeconds;

        private void Start() {
            if(_scoreText != null)
                _scoreText.text = $"X{_scoreMultiplier.ToString()}";

            _delayToWinWaitForSeconds = new WaitForSeconds(_delayToWin);
        }

        public void OnSlicerHandleHit(PlayerController playerController) {
            playerController.JumpBack();
        }

        public void OnSlicerSharpEdgeHit(PlayerController playerController) {
            if(GameStateController.Instance.CurrentGameState != GameStates.InGame) return;

            StartCoroutine(PlayerWinCoroutine(playerController));
        }

        private IEnumerator PlayerWinCoroutine(PlayerController playerController) {
            playerController.Stuck(true);

            yield return _delayToWinWaitForSeconds;

            OnPlayerWin?.Invoke(_scoreMultiplier);
        }
    }
}
