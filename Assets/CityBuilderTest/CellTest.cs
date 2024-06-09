using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace CityBuilder.Test
{
    public class CellTest
    {

        [Test]
        public void CellSetGameObjectPass()
        {
            Cell cell = new Cell();
            cell.SetConstruction(new GameObject());
            Assert.IsTrue(cell.IsTaken);
        }

        [Test]
        public void CellSetGameObjectNullFail()
        {
            Cell cell = new Cell();
            cell.SetConstruction(null);
            Assert.IsFalse(cell.IsTaken);
        }

    }
}