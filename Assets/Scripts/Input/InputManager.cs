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
                    Debug.Log(hit.point - transform.position);
                }
            }
        }
    }
}
