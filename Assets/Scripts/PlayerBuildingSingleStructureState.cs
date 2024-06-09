using UnityEngine;

namespace CityBuilder
{
    public class PlayerBuildingSingleStructureState : PlayerState
    {

        private PlacementManager _placementManager;
        private GridStructure _gridStructure;
        public PlayerBuildingSingleStructureState(GameManager gameManager, PlacementManager placementManager, GridStructure gridStructure) : base(gameManager)
        {
            _placementManager = placementManager;
            _gridStructure = gridStructure;
        }

        public override void OnInputPointerDown(Vector3 position)
        {
            var calculateGridPosition = _gridStructure.CalculateGridPosition(position);
            if(_gridStructure.IsCellTaken(calculateGridPosition))
                _placementManager.CreateBuilding(calculateGridPosition, _gridStructure);
        }

        public override void OnInputPointerChange(Vector3 position)
        {
        }

        public override void OnInputPanChange(Vector3 position)
        {
        }

        public override void OnInputPanUpChange()
        {
        }

        public override void OnInputPointerUp()
        {
        }

        public override void Cancel()
        {
        }
    }
}