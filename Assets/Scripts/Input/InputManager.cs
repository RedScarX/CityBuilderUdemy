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

        private Action<Vector3> _onPointerDownHandler;
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
            if (!Input.GetMouseButtonDown(0) || EventSystem.current.IsPointerOverGameObject()) return;
            
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            var rayCast = Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, Mathf.Infinity,
                layerMask);

            if (!rayCast) return;
            var position = hit.point - transform.position;
            _onPointerDownHandler?.Invoke(position);
        }

        public void AddListenerOnPointerDownEvent(Action<Vector3> listener) => _onPointerDownHandler += listener;
        public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener) => _onPointerDownHandler -= listener;
    }
}
