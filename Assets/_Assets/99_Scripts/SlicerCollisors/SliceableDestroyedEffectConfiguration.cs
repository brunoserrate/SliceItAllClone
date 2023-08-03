using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    [CreateAssetMenu(
        fileName = "SliceableDestroyedEffectConfiguration",
        menuName = "SerrateDevs/SliceItAllClone/SliceableDestroyedEffectConfiguration"
    )]
    public class SliceableDestroyedEffectConfiguration : ScriptableObject {
        public float explosionForce = 100f;
    }
}
