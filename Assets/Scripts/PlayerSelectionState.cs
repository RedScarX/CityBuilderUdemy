using UnityEngine;

namespace CityBuilder
{
    public class PlayerSelectionState : PlayerState
    {
        private CameraMovement _cameraMovement;
        public PlayerSelectionState(GameManager gameManager, CameraMovement cameraMovement) : base(gameManager)
        {
            _cameraMovement = cameraMovement;
        }

        public override void OnInputPointerDown(Vector3 position)
        {
        }

        public override void OnInputPointerChange(Vector3 position)
        {
        }

        public override void OnInputPanChange(Vector3 position)
        {
            _cameraMovement.MoveCamera(position);
        }

        public override void OnInputPanUpChange()
        {
            _cameraMovement.StopCameraMovement();
        }

        public override void OnInputPointerUp()
        {
        }

        public override void Cancel()
        {
        }
    }
}