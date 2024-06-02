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
        private const float CellSize = 3;

        private void Start()
        {
            _gridStructure = new GridStructure(CellSize);
            inputManager.AddListenerOnPointerDownEvent(HandleInput);
        }

        private void OnDestroy()
        {
           inputManager.RemoveListenerOnPointerDownEvent(HandleInput); 
        }

        private void HandleInput(Vector3 position)
        {
            placementManager.CreateBuilding(_gridStructure.CalculateGridPosition(position));
        }
    }
}