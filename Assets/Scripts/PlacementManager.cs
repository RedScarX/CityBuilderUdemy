using UnityEngine;

namespace CityBuilder 
{
    public class PlacementManager : MonoBehaviour
    { 
        [SerializeField] private GameObject buildingPrefab;
        [SerializeField] private Transform groundParent;
        public void CreateBuilding(Vector3 gridPosition)
        {
            Instantiate(buildingPrefab, groundParent.position+gridPosition, Quaternion.identity);
        }
    }
}
