using UnityEngine;

namespace CityBuilder
{
    public class Cell
    {
        private GameObject _structureModel = null;
        public bool IsTaken { get; private set; } = false;

        public void SetConstruction(GameObject structureModel)
        {
            if (structureModel == null) return;

            this._structureModel = structureModel;
            IsTaken = true;
            
        }
    }
}