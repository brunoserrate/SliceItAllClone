using System;
using System.Collections;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class PlayerController : MonoBehaviour {
        [Header("Components")]
        [SerializeField] private Rigidbody rb;

        [Header("Settings")]
        [Tooltip("The force direction applied when the player taps the screen")]
        [SerializeField] private Vector3 _frontForceDirection;
        [Tooltip("The force direction when the slicer's handle hit a platform or a wall")]
        [SerializeField] private Vector3 _backForceDirection;

        [Space(5)]
        [Tooltip("The rotation force applied when the player taps the screen")]
        [SerializeField] private Vector3 _frontRotationForce;
        [Tooltip("The rotation force when the slicer's handle hit a platform or a wall")]
        [SerializeField] private Vector3 _backRotationForce;


        // <summary>
        // If the player can stuck when it hits a platform or a wall. Prevents the player from getting stuck in the same place
        // </summary>
        private bool _canStuck = true;

        // <summary>
        // If its stop reading the inputs. Prevents the player from jumping when is already in win or lose state
        // </summary>
        private bool _stopReadingInput = false;

        // <summary>
        // The time to wait to the player can stuck again. The variable prevents to put more work on the garbage collector
        // </summary>
        private WaitForSeconds _waitToStuck;

        private void Start() {
            rb.isKinematic = true;
            _stopReadingInput = false;

            _waitToStuck = new WaitForSeconds(0.5f);
        }

        private void OnEnable() {
            InputReader.OnTap += HandleTap;
        }

        private void OnDisable() {
            InputReader.OnTap -= HandleTap;
        }

        private void Update() {
            StillInGameState();
        }

        private void FixedUpdate() {
            rb.inertiaTensorRotation = Quaternion.identity;
        }

        private void HandleTap() {
            if(GameStateController.Instance.CurrentGameState != GameStates.InGame) return;

            if(_stopReadingInput) return;

            Jump();
            Spin();
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

            // Reset the velocity to prevent the player from going to far
            rb.velocity = Vector3.zero;
            rb.AddForce(_forceDirection, ForceMode.Impulse);
        }

        private void Spin(bool spinFoward = true) {
            Vector3 _rotationForce = spinFoward ? _frontRotationForce : _backRotationForce;

            // Reset the velocity to prevent the rotation from going crazy
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

        // <summary>
        // Prevents the player to move when it's on win or lose state
        // </summary>
        private void StillInGameState() {
            if(GameStateController.Instance.CurrentGameState == GameStates.InGame) return;

            if(IsStuck()) return;

            Stuck();
        }

        // <summary>
        // Stops the player from moving when hit a platform or a wall
        // Stops reading the input to prevent the player from jumping when is already in win or lose state
        // </summary>

        public void Stuck(bool stopReadingInput = false) {
            if(!_canStuck) return;
            rb.isKinematic = true;
            _canStuck = false;

            if(stopReadingInput)
                _stopReadingInput = true;
        }

        private IEnumerator TimerToStuck() {
            yield return _waitToStuck;
            _canStuck = true;
        }

        public void JumpBack() {
            Jump(false);
            Spin(false);
        }
    }
}
