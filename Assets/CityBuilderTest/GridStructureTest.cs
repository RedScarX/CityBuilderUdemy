using System;
using CityBuilder;
using NUnit.Framework;
using UnityEngine;

namespace CityBuilder.Test
{
    public class GridStructureTest
    {
        private GridStructure _gridStructure;

        [OneTimeSetUp]
        public void Init()
        {
            _gridStructure = new GridStructure(3,100,100);
        }

        [Test]
        public void CalculateGridPositionForZeroInput()
        {
           var returnPosition =  _gridStructure.CalculateGridPosition(Vector3.zero);
           Assert.AreEqual(Vector3.zero,returnPosition);
        }
        [Test]
        public void CalculateGridPositionForFloatInput()
        {
           var returnPosition =  _gridStructure.CalculateGridPosition(new Vector3( 2.9f,0,2.6f));
           Assert.AreEqual(Vector3.zero,returnPosition);
        }
        
        [Test]
        public void CalculateGridPositionForGreaterInput()
        {
           var returnPosition =  _gridStructure.CalculateGridPosition(new Vector3( 3.9f,0,2.6f));
           Assert.AreEqual(new Vector3(3,0,0),returnPosition);
        }
        
         #region GridIndexTests
        //[Test]
        //public void CalculateGridIndexFromGridPosition000Passes()
        //{

        //    Vector3 position = new Vector3(0, 0, 0);
        //    //Act
        //    Vector3 returnPosition = structure.CalculateGridPosition(position);
        //    Vector2Int indexInsideGrid = structure.CalculateGridIndex(returnPosition);
        //    //Assert
        //    Assert.AreEqual(Vector2Int.zero, indexInsideGrid);
        //}
        //[Test]
        //public void CalculateGridIndexFromGridPosition303Passes()
        //{

        //    Vector3 position = new Vector3(3, 0, 3);
        //    //Act
        //    Vector3 returnPosition = structure.CalculateGridPosition(position);
        //    Vector2Int indexInsideGrid = structure.CalculateGridIndex(returnPosition);
        //    //Assert
        //    Assert.AreEqual(new Vector2Int(1,1), indexInsideGrid);
        //}
        //[Test]
        //public void CalculateGridIndexFromGridPosition301Fail()
        //{

        //    Vector3 position = new Vector3(3, 0, 1);
        //    //Act
        //    Vector3 returnPosition = structure.CalculateGridPosition(position);
        //    Vector2Int indexInsideGrid = structure.CalculateGridIndex(returnPosition);
        //    //Assert
        //    Assert.AreNotEqual(new Vector2Int(1, 1), indexInsideGrid);
        //}
        #endregion

        #region GridCellTests
        [Test]
        public void PlaceStructure303AndCheckIsTakenPasses()
        {

            Vector3 position = new Vector3(3, 0, 3);
            //Act
            Vector3 returnPosition = _gridStructure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            _gridStructure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(_gridStructure.IsCellTaken(position));
        }
        [Test]
        public void PlaceStructureMinAndCheckIsTakenPasses()
        {

            Vector3 position = new Vector3(0, 0, 0);
            //Act
            Vector3 returnPosition = _gridStructure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            _gridStructure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(_gridStructure.IsCellTaken(position));
        }
        [Test]
        public void PlaceStructureMaxAndCheckIsTakenPasses()
        {

            Vector3 position = new Vector3(297, 0, 297);
            //Act
            Vector3 returnPosition = _gridStructure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            _gridStructure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(_gridStructure.IsCellTaken(position));
        }

        [Test]
        public void PlaceStructure303AndCheckIsTakenNullObjectShouldFail()
        {

            Vector3 position = new Vector3(3, 0, 3);
            //Act
            Vector3 returnPosition = _gridStructure.CalculateGridPosition(position);
            GameObject testGameObject = null;
            _gridStructure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsFalse(_gridStructure.IsCellTaken(position));
        }

        [Test]
        public void PlaceStructureAndCheckIsTakenIndexOutOfBoundsFail()
        {

            Vector3 position = new Vector3(303, 0, 303);
            //Act
            //Assert
            Assert.Throws<IndexOutOfRangeException>(()=>_gridStructure.IsCellTaken(position));
        }

        #endregion
    }
}
