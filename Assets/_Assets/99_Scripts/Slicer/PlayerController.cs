using System;
using System.Collections;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class PlayerController : MonoBehaviour {
        [Header("Components")]
        [SerializeField] private Rigidbody rb;

        [Header("Settings")]
        [SerializeField] private Vector3 _frontForceDirection;
        [SerializeField] private Vector3 _backForceDirection;

        [Space(5)]
        [SerializeField] private Vector3 _frontRotationForce;
        [SerializeField] private Vector3 _backRotationForce;

        private bool _canStuck = true;
        private bool _stopReadingInput = false;

        // TODO: Refactor to a new component: input reader
        public static Action OnTap;

        private void Start() {
            rb.isKinematic = true;
            _stopReadingInput = false;
        }

        // TODO: Refactor to a new component: input reader
        private void Update() {
            if(_stopReadingInput) return;

            if(Input.GetMouseButtonDown(0)) {
                OnTap?.Invoke();

                if(GameStateController.Instance.CurrentGameState != GameStates.InGame) return;

                Jump();
                Spin();
            }
        }

        private void FixedUpdate() {
            rb.inertiaTensorRotation = Quaternion.identity;
        }

        private void Jump(bool jumpFoward = true) {
            if(GameStateController.Instance.CurrentGameState != GameStates.InGame) {
                Stuck();
                return;
            }

            if(IsStuck()) {
                UnStuck();
            }

            Vector3 _forceDirection = jumpFoward ? _frontForceDirection : _backForceDirection;

            rb.velocity = Vector3.zero;
            rb.AddForce(_forceDirection, ForceMode.Impulse);
        }

        private void Spin(bool spinFoward = true) {
            Vector3 _rotationForce = spinFoward ? _frontRotationForce : _backRotationForce;

            rb.angularVelocity = Vector3.zero;
            rb.AddTorque(_rotationForce, ForceMode.Acceleration);
        }

        private bool IsStuck(){
            return rb.isKinematic;
        }

        private void UnStuck(){
            rb.isKinematic = false;
            StartCoroutine(TimerToStuck());
        }

        public void Stuck(bool stopReadingInput = false) {
            if(!_canStuck) return;
            rb.isKinematic = true;
            _canStuck = false;

            if(stopReadingInput)
                _stopReadingInput = true;
        }

        private IEnumerator TimerToStuck() {
            yield return new WaitForSeconds(0.5f);
            _canStuck = true;
        }

        public void JumpBack() {
            Jump(false);
            Spin(false);
        }
    }
}
