using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public class NextLevelUI : MonoBehaviour {
        public static System.Action OnNextLevel;

        public void NextLevel() {
            OnNextLevel?.Invoke();
        }
    }
}
