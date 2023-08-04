using System;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class DeathZone : MonoBehaviour, ISlicerCollisor {

        public static Action OnPlayerLose;
        public void OnSlicerHandleHit(PlayerController playerController) {
            if(GameStateController.Instance.CurrentGameState != GameStates.InGame) return;

            PlayerLose(playerController);
        }

        public void OnSlicerSharpEdgeHit(PlayerController playerController) {
            if(GameStateController.Instance.CurrentGameState != GameStates.InGame) return;

            PlayerLose(playerController);
        }

        private void PlayerLose(PlayerController playerController) {
            playerController.Stuck();
            OnPlayerLose?.Invoke();
        }
    }
}
