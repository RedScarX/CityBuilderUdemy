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
    }
}
