using UnityEngine;

namespace CityBuilder
{
    public class GridStructure
    {
        private readonly float _cellSize;

        public GridStructure(float cellSize)
        {
            _cellSize = cellSize;
        }

        public Vector3 CalculateGridPosition(Vector3 inputPosition)
        {
            int x = Mathf.FloorToInt(inputPosition.x / _cellSize);
            int z = Mathf.FloorToInt(inputPosition.z / _cellSize);

            return new Vector3(x * _cellSize, 0, z * _cellSize);
        }
    }
}