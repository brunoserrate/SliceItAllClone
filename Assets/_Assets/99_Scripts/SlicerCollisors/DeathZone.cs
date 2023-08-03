using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class DeathZone : MonoBehaviour, ISlicerCollisor {
        public void OnSlicerHandleHit(PlayerController playerController) {
            PlayerLose(playerController);
        }

        public void OnSlicerSharpEdgeHit(PlayerController playerController) {
            PlayerLose(playerController);
        }

        private void PlayerLose(PlayerController playerController) {
            // TODO: Trigger Event to Lose
            Debug.Log("Player Lose");
            playerController.Stuck();
        }
    }
}
