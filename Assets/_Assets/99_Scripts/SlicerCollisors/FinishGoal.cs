using System;
using System.Collections;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class FinishGoal : MonoBehaviour, ISlicerCollisor
    {
        public static event Action<float> OnPlayerWin;

        [SerializeField] private float _scoreMultiplier = 1f;
        [SerializeField] private TMPro.TextMeshProUGUI _scoreText;

        [Space(10)]

        [SerializeField] private float _delayToWin = 0.5f;
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
            playerController.Stuck();

            yield return _delayToWinWaitForSeconds;

            OnPlayerWin?.Invoke(_scoreMultiplier);
        }
    }
}
