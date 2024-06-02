using UnityEngine;

namespace CityBuilder 
{
    public class PlacementManager : MonoBehaviour
    { 
        [SerializeField] private GameObject buildingPrefab;
        [SerializeField] private Transform groundParent;
        public void CreateBuilding(Vector3 gridPosition, GridStructure structure)
        {
            var newStructure = Instantiate(buildingPrefab, groundParent.position+gridPosition, Quaternion.identity);
            structure.PlaceStructureOnTheGrid(newStructure,gridPosition);
        }
    }
}
