using System;
using System.Collections;
using System.Collections.Generic;
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

        private void Start() {
            rb.isKinematic = true;
        }

        private void Update() {
            if(Input.GetMouseButtonDown(0)) {
                Jump();
                Spin();
            }
        }

        private void FixedUpdate() {
            rb.inertiaTensorRotation = Quaternion.identity;
        }

        private void Jump(bool jumpFoward = true) {
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

        public void Stuck() {
            if(!_canStuck) return;
            rb.isKinematic = true;
            _canStuck = false;
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
