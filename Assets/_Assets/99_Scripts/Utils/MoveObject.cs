using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs {
    public class MoveObject : MonoBehaviour {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private Vector3 _direction = Vector3.forward;

        private Vector3 _normalizedDirection;

        private void Awake() {
            _normalizedDirection = _direction.normalized;
        }

        private void Update() {
            transform.Translate(_normalizedDirection * (_speed * Time.deltaTime));
        }
    }
}
