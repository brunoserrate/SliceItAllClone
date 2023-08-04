using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class Sliceable : MonoBehaviour, ISlicerCollisor {

        public static event System.Action<int> OnSliceableDestroyed;

        [Header("Sliceable Configuration")]
        [Tooltip("The score value when the player destroys this sliceable")]
        [Min(1)]
        [SerializeField] private int _scoreValue = 1;

        [Header("Sliceable Components")]
        [SerializeField] private Rigidbody[] _rigidbodiesParts;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private SliceableDestroyedEffectConfiguration _sliceableDestroyedEffectConfiguration;

        [Space(5)]
        [SerializeField] private TMPro.TextMeshProUGUI _scoreText;

        private bool _isSliced = false;

        private void Start() {
            _scoreText.text = $"+{_scoreValue.ToString()}";
            _scoreText.gameObject.SetActive(false);
        }

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

        // <summary>
        // Slices the sliceable and apply the explosion force to the parts
        // The first part of the sliceable will be pushed forward and the second part will be pushed backwards (that's why the z axis is multiplied by -2)
        // </summary>
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

            _scoreText.gameObject.SetActive(true);

            _particleSystem.Play();
        }
    }
}
