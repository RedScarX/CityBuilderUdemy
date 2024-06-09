using System;
using System.Collections;
using System.Collections.Generic;
using PlasticGui.WebApi.Responses;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace CityBuilder 
{
    public class InputManager : MonoBehaviour, IInputManager
    {
        private Camera _mainCamera;
        [SerializeField] private LayerMask layerMask;

        private Action<Vector3> _onPointerDownHandler;
        private Action<Vector3> _onPointerSecondChangeHandler;
        private Action<Vector3> _onPointerChangeHandler;
        private Action _onPointerSecondUpHandler;
        private Action _onPointerUpHandler;
        private void Start()
        {
            _mainCamera = Camera.main; 
        }

        private void Update()
        {
            GetPointerPosition(); 
            GetPanningPointer();
        }

        private void GetPointerPosition()
        {
            Vector3? position = null;
            if (GetMousePosition(ref position)) return;
    
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                OnPointerDown(position);
    
            if (Input.GetMouseButton(0))
                OnPointerChange(position);
    
            if (Input.GetMouseButtonUp(0))
                OnPointerUp();
        }

        private bool GetMousePosition(ref Vector3? position)
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            var rayCast = Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, Mathf.Infinity, layerMask);
    
            if (!rayCast) return true;
            position = hit.point - transform.position;
            return false;
        }

        private void OnPointerDown(Vector3? position)
        {
            if (position != null) _onPointerDownHandler?.Invoke(position.Value);
        }

        private void OnPointerChange(Vector3? position)
        {
            if (position != null) _onPointerChangeHandler?.Invoke(position.Value);
        }

        private void OnPointerUp()
        {
            _onPointerUpHandler?.Invoke();
        }

        private void GetPanningPointer()
        {
            if(Input.GetMouseButton(1))
                _onPointerSecondChangeHandler?.Invoke(Input.mousePosition);
            if(Input.GetMouseButtonUp(1))
                _onPointerSecondUpHandler?.Invoke();
        }

        public void AddListenerOnPointerDownEvent(Action<Vector3> listener) => _onPointerDownHandler += listener;
        public void AddListenerOnPointerUpEvent(Action listener) => _onPointerUpHandler += listener;

        public void AddListenerOnPointerChangeEvent(Action<Vector3> listener) => _onPointerChangeHandler += listener;

        public void RemoveListenerOnPointerUpEvent(Action listener) => _onPointerUpHandler -= listener;

        public void RemoveListenerOnPointerChangeEvent(Action<Vector3> listener) => _onPointerChangeHandler -= listener;

        public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener) => _onPointerDownHandler -= listener;
        public void AddListenerOnPointerSecondChangeEvent(Action<Vector3> listener) => _onPointerSecondChangeHandler += listener;
        public void RemoveListenerOnPointerSecondChangeEvent(Action<Vector3> listener) => _onPointerSecondChangeHandler -= listener;
        public void AddListenerOnPointerSecondUpEvent(Action listener) => _onPointerSecondUpHandler += listener;
        public void RemoveListenerOnPointerSecondUpEvent(Action listener) => _onPointerSecondUpHandler -= listener;
    }
}
