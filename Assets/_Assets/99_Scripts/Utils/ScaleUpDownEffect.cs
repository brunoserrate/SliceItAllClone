using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs {
    public class ScaleUpDownEffect : MonoBehaviour {

        [SerializeField] private float _delayToStart = 1f;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Vector3 _initialScale = Vector3.zero;
        [SerializeField] private Vector3 _targetScale = Vector3.zero;
        [SerializeField] private AnimationCurve _animationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        private float _timer = 0f;
        private WaitForSeconds _delayToStartWaitForSeconds;
        private bool _scalingUp = true;
        private Vector3 _auxScale;

        private void Start() {
            _delayToStartWaitForSeconds = new WaitForSeconds(_delayToStart);
        }

        private void OnEnable() {
            _timer = 0f;
            _scalingUp = true;
            StartCoroutine(ScaleUpDownCoroutine());
        }

        private void OnDisable() {
            StopAllCoroutines();
        }

        private IEnumerator ScaleUpDownCoroutine() {
            // yield return _delayToStartWaitForSeconds;
            transform.localScale = _initialScale;

            yield return _delayToStartWaitForSeconds;

            while(true){
                _timer += Time.deltaTime;

                if(_scalingUp){
                    _auxScale = Vector3.Lerp(_initialScale, _targetScale, _animationCurve.Evaluate(_timer / _duration));
                }
                else {
                    _auxScale = Vector3.Lerp(_targetScale, _initialScale, _animationCurve.Evaluate(_timer / _duration));
                }

                transform.localScale = _auxScale;

                if(_timer >= _duration) {
                    _timer = 0f;
                    _scalingUp = !_scalingUp;
                }

                if(gameObject.activeSelf == false) break;

                yield return 0;
            }

        }
    }
}
