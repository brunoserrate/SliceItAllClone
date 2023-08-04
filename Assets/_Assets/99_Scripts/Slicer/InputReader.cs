using System;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class InputReader : MonoBehaviour {

        public static Action OnTap;
        private void Update() {
            #if UNITY_EDITOR
            if(Input.GetMouseButtonDown(0)) {
                OnTap?.Invoke();
            }
            #endif

            #if UNITY_ANDROID
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
                OnTap?.Invoke();
            }
            #endif
        }
    }
}
