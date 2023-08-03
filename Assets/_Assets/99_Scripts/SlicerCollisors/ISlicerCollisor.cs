using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerrateDevs.SliceItAllClone {
    public interface ISlicerCollisor {
        void OnSlicerSharpEdgeHit(PlayerController playerController);
        void OnSlicerHandleHit(PlayerController playerController);
    }
}
