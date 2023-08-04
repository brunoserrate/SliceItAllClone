using System.Collections;
using UnityEngine;

namespace SerrateDevs {
    public class ScaleOut : MonoBehaviour {

        [SerializeField] private float _delayToStart = 1f;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Vector3 _targetScale = Vector3.zero;
        [SerializeField] private AnimationCurve _animationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        private float _timer = 0f;

        private WaitForSeconds _delayToStartWaitForSeconds;
        private void Start() {
            _timer = 0f;
            _delayToStartWaitForSeconds = new WaitForSeconds(_delayToStart);
            StartCoroutine(ScaleOutCoroutine());
        }

        private IEnumerator ScaleOutCoroutine() {
            Vector3 initialScale = transform.localScale;

            yield return _delayToStartWaitForSeconds;

            while(_timer < _duration) {
                _timer += Time.deltaTime;
                transform.localScale = Vector3.Lerp(initialScale, _targetScale, _animationCurve.Evaluate(_timer / _duration));
                yield return 0;
            }

            gameObject.SetActive(false);
        }
    }
}
