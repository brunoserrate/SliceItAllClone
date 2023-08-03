using System;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class DeathZone : MonoBehaviour, ISlicerCollisor {

        public static Action OnPlayerLose;
        public void OnSlicerHandleHit(PlayerController playerController) {
            PlayerLose(playerController);
        }

        public void OnSlicerSharpEdgeHit(PlayerController playerController) {
            PlayerLose(playerController);
        }

        private void PlayerLose(PlayerController playerController) {
            playerController.Stuck();
            OnPlayerLose?.Invoke();
        }
    }
}
