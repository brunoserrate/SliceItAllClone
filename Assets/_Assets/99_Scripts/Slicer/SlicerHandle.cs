using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class SlicerHandle : MonoBehaviour {

        private PlayerController _playerController;

        private void Awake() {
            _playerController = GetComponentInParent<PlayerController>();
        }

        private void OnTriggerEnter(Collider other) {
            if(other.TryGetComponent(out ISlicerCollisor slicerCollisor)) {
                slicerCollisor.OnSlicerHandleHit(_playerController);
            }
        }
    }
}
