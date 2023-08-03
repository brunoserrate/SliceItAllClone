using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class RestartLevelUI : MonoBehaviour {
        public static System.Action OnRestartLevel;

        public void RestartLevel() {
            OnRestartLevel?.Invoke();
        }
    }
}
