using System;
using UnityEngine;

namespace CityBuilder
{
    public class GridStructure
    {
        private readonly float _cellSize;
        private Cell[,] _grid;
        private int _width;
        private int _length;

        public GridStructure(float cellSize, int width, int length)
        {
            _cellSize = cellSize;
            _width = width;
            _length = length;
            _grid = new Cell[_width, _length];
            for (int row = 0; row < _grid.GetLength(0); row++)
            {
                for (int col = 0; col < _grid.GetLength(1); col++)
                {
                    _grid[row, col] = new Cell();
                }
            }
        }

        public Vector3 CalculateGridPosition(Vector3 inputPosition)
        {
            int x = Mathf.FloorToInt(inputPosition.x / _cellSize);
            int z = Mathf.FloorToInt(inputPosition.z / _cellSize);

            return new Vector3(x * _cellSize, 0, z * _cellSize);
        }

        private Vector2Int CalculateGridIndex(Vector3 gridPosition)
        {
            return new Vector2Int((int)(gridPosition.x / _cellSize), (int)(gridPosition.z / _cellSize));
        }

        public bool IsCellTaken(Vector3 gridPosition)
        {
            var cellIndex = CalculateGridIndex(gridPosition);
            if (CheckIndexValidity(cellIndex))
                return _grid[cellIndex.y, cellIndex.x].IsTaken;

            throw new IndexOutOfRangeException($"NO index {cellIndex} in grid.");
        }

        public void PlaceStructureOnTheGrid(GameObject sturcture, Vector3 gridPosition)
        {
            var cellIndex = CalculateGridIndex(gridPosition);
            if (CheckIndexValidity(cellIndex))
                _grid[cellIndex.y, cellIndex.x].SetConstruction(sturcture);
            
        }

        private bool CheckIndexValidity(Vector2Int cellIndex)
        {
            return cellIndex.x >= 0 && cellIndex.x < _grid.GetLength(1) && cellIndex.y >= 0 &&
                   cellIndex.y < _grid.GetLength(0);
        }
    }
}