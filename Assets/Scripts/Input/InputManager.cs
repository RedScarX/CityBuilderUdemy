using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace CityBuilder 
{
    public class InputManager : MonoBehaviour
    {
        private Camera _mainCamera;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float cellSize = 3;
        [SerializeField] private GameObject buildingPrefab;
        

        private void Start()
        {
            _mainCamera = Camera.main; 
        }

        private void Update()
        {
            GetInput(); 
        }

        private void GetInput()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                var rayCast = Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, Mathf.Infinity,
                    layerMask);

                if (rayCast)
                {
                    var position = hit.point - transform.position;
                    // Debug.Log(CalculateGridPosition(position));
                    // CreateBuilding(CalculateGridPosition(position));
                }
            }
        }


        // private void CreateBuilding(Vector3 gridPosition)
        // {
        //     Instantiate(buildingPrefab, gridPosition, Quaternion.identity);
        // }
    }
}
