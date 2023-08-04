using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class Sliceable : MonoBehaviour, ISlicerCollisor {

        public static event System.Action<int> OnSliceableDestroyed;

        [Header("Sliceable Configuration")]
        [Min(1)]
        [SerializeField] private int _scoreValue = 1;

        [Header("Sliceable Components")]
        [SerializeField] private Rigidbody[] _rigidbodiesParts;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private SliceableDestroyedEffectConfiguration _sliceableDestroyedEffectConfiguration;


        private bool _isSliced = false;

        public void OnSlicerHandleHit(PlayerController playerController) {
            if(_isSliced) return;

            playerController.JumpBack();
        }

        public void OnSlicerSharpEdgeHit(PlayerController playerController) {
            if(_isSliced) return;
            _isSliced = true;

            Slice();
            OnSliceableDestroyed?.Invoke(_scoreValue);
        }

        private void Slice(){
            for (int i = 0; i < _rigidbodiesParts.Length; i++) {
                _rigidbodiesParts[i].isKinematic = false;
                Vector3 explosionDirection = _sliceableDestroyedEffectConfiguration.explosionDirection;

                if(i > 0){
                    explosionDirection.z *= -2;
                }

                _rigidbodiesParts[i].AddForce(
                    _sliceableDestroyedEffectConfiguration.explosionForce * explosionDirection,
                    ForceMode.Impulse
                );
            }
            foreach (var rbPart in _rigidbodiesParts) {
                rbPart.isKinematic = false;
                rbPart.AddForce(
                    _sliceableDestroyedEffectConfiguration.explosionForce * _sliceableDestroyedEffectConfiguration.explosionDirection,
                    ForceMode.Impulse
                );

                _particleSystem.Play();
            }
        }
    }
}
