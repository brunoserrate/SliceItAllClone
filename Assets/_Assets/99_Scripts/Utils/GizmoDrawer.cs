using UnityEngine;

namespace SerrateDevs {
    public class GizmoDrawer : MonoBehaviour {
        [SerializeField] private Color color = Color.red;
        [Min(0.1f)]
        [SerializeField] private float radius = 0.5f;

        private void OnDrawGizmos() {
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
