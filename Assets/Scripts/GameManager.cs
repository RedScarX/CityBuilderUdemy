using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace CityBuilder
{
    public class GameManager : MonoBehaviour
    {
        private IInputManager _inputManager;

        [SerializeField] private UIController uiController;
        [SerializeField] private CameraMovement cameraMovement;

        private PlayerState _playerState;
        private GridStructure _gridStructure;
        
        
        [SerializeField] private int width;
        [SerializeField] private int length;

        private const float CellSize = 3;
        private bool _buildingModeActive = false;

        private void Start()
        {
            cameraMovement.SetCameraLimit(0, width, 0, length);
            _inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
            _inputManager?.AddListenerOnPointerDownEvent(HandleInput);
            _inputManager?.AddListenerOnPointerChangeEvent(HandlePointerChange);
            _inputManager?.AddListenerOnPointerSecondChangeEvent(HandleInputCameraPanning);
            _inputManager?.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
            uiController.AddListenerBuildAreaEvent(StartPlacementMode);
            uiController.AddListenerCancelActionEvent(CancelAction);
            
        }


        private void OnDestroy()
        {
            _inputManager?.RemoveListenerOnPointerDownEvent(HandleInput); 
            _inputManager?.RemoveListenerOnPointerSecondChangeEvent(HandleInputCameraPanning);
            _inputManager?.RemoveListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
            uiController.RemoveListenerBuildAreaEvent(StartPlacementMode);
            uiController.RemoveListenerCancelActionEvent(CancelAction);
        }

        private void HandleInput(Vector3 position)
        {
        }

        private void StartPlacementMode() => _buildingModeActive = true;
        private void CancelAction() => _buildingModeActive = false;

        private void HandleInputCameraPanStop()
        {
        }

        private void HandlePointerChange(Vector3 obj)
        {
            Debug.Log($"{obj}");
        }

        private void HandleInputCameraPanning(Vector3 position)
        {
        }
    }
}