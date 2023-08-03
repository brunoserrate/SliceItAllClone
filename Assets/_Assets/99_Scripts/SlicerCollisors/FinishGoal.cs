using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class FinishGoal : MonoBehaviour, ISlicerCollisor
    {
        public static event Action<float> OnPlayerWin;

        [SerializeField] private float _scoreMultiplier = 1f;
        public void OnSlicerHandleHit(PlayerController playerController) {
            playerController.JumpBack();
        }

        public void OnSlicerSharpEdgeHit(PlayerController playerController) {
            PlayerWin(playerController);
        }

        private void PlayerWin(PlayerController playerController) {
            playerController.Stuck();

            OnPlayerWin?.Invoke(_scoreMultiplier);
        }
    }
}
