namespace SerrateDevs.SliceItAllClone {
    public interface ISlicerCollisor {
        void OnSlicerSharpEdgeHit(PlayerController playerController);
        void OnSlicerHandleHit(PlayerController playerController);
    }
}
