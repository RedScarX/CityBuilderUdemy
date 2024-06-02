using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CityBuilder
{
    public class GameManager : MonoBehaviour
    {
        public PlacementManager placementManager;
        public InputManager inputManager;

        private GridStructure _gridStructure;
        [SerializeField] private int width;
        [SerializeField] private int length;
        private const float CellSize = 3;

        private void Start()
        {
            _gridStructure = new GridStructure(CellSize,width,length);
            inputManager.AddListenerOnPointerDownEvent(HandleInput);
        }

        private void OnDestroy()
        {
           inputManager.RemoveListenerOnPointerDownEvent(HandleInput); 
        }

        private void HandleInput(Vector3 position)
        {
            var calculateGridPosition = _gridStructure.CalculateGridPosition(position);
            if(!_gridStructure.IsCellTaken(calculateGridPosition))
                placementManager.CreateBuilding(calculateGridPosition, _gridStructure);
        }
    }
}