using System;
using System.Collections;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class DeathZone : MonoBehaviour, ISlicerCollisor {

        public static Action OnPlayerLose;

        [Header("Settings")]
        [Tooltip("The time to wait to the player lose after it hits the death zone")]
        [SerializeField] private float _delayToLose = 0.5f;
        private WaitForSeconds _delayToLoseWaitForSeconds;

        private void Start() {
            _delayToLoseWaitForSeconds = new WaitForSeconds(_delayToLose);
        }
        public void OnSlicerHandleHit(PlayerController playerController) {
            if(GameStateController.Instance.CurrentGameState != GameStates.InGame) return;

            StartCoroutine(PlayerLoseCoroutine(playerController));
        }

        public void OnSlicerSharpEdgeHit(PlayerController playerController) {
            if(GameStateController.Instance.CurrentGameState != GameStates.InGame) return;

            StartCoroutine(PlayerLoseCoroutine(playerController));
        }

        private IEnumerator PlayerLoseCoroutine(PlayerController playerController) {
            playerController.Stuck(true);

            yield return _delayToLoseWaitForSeconds;

            OnPlayerLose?.Invoke();
        }
    }
}
