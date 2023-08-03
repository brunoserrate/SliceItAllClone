using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class GroundWall : MonoBehaviour, ISlicerCollisor {
        public void OnSlicerSharpEdgeHit(PlayerController playerController) {
            playerController.Stuck();
        }

        public void OnSlicerHandleHit(PlayerController playerController) {
            playerController.JumpBack();
        }
    }
}
