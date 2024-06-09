using System;
using UnityEngine;

namespace CityBuilder
{
    public class CameraMovement : MonoBehaviour
    {
        private Vector3? _basePointerPosition = null;
        public float cameraMovementSpeed = .05f;
        private int _cameraXMin;
        private int _cameraZMin;
        private int _cameraXMax;
        private int _cameraZMax;

        public void MoveCamera(Vector3 pointerPosition)
        {
            if (_basePointerPosition.HasValue == false)
                _basePointerPosition = pointerPosition;

            Vector3 newPosition = pointerPosition - _basePointerPosition.Value;
            newPosition = new Vector3(newPosition.x, 0, newPosition.y);
            transform.Translate(newPosition * cameraMovementSpeed);

            LimitPositionInsideCameraBounds();
        }
        
        private void LimitPositionInsideCameraBounds()
        {
            var transformPosition = transform.position;
            transformPosition = new Vector3(Mathf.Clamp(transformPosition.x, _cameraXMin, _cameraXMax), 0,
                Mathf.Clamp(transformPosition.z, _cameraZMin, _cameraZMax));
            transform.position = transformPosition;
        }

        public void StopCameraMovement() => _basePointerPosition = null;

        public void SetCameraLimit(int cameraXMin, int cameraXMax, int cameraZMin, int cameraZMax)
        {
            _cameraXMin = cameraXMin;
            _cameraXMax = cameraXMax;
            _cameraZMin = cameraZMin;
            _cameraZMax = cameraZMax;
        }
    }
}