using System;
using UnityEngine;
using UnityEngine.UI;

namespace CityBuilder
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button buildResidentialAreaBuildingBtn;
        [SerializeField] private Button cancelActionBtn;
        [SerializeField] private GameObject cancelActionPanel;
        
        private Action _onBuildAreaHandler;
        private Action _onCancelActionHandler;

        private void Start()
        {
            buildResidentialAreaBuildingBtn.onClick.AddListener(OnBuildAreaCallback); 
            cancelActionBtn.onClick.AddListener(OnCancelActionCallback);
        }

        private void OnBuildAreaCallback()
        {
            cancelActionPanel.SetActive(true);
            _onBuildAreaHandler?.Invoke();
        }
        private void OnCancelActionCallback()
        {
            cancelActionPanel.SetActive(false);
            _onCancelActionHandler?.Invoke();
        }

        public void AddListenerBuildAreaEvent(Action listener) => _onBuildAreaHandler += listener;
        public void RemoveListenerBuildAreaEvent(Action listener) => _onBuildAreaHandler -= listener;

        public void AddListenerCancelActionEvent(Action listener) => _onCancelActionHandler += listener;
        public void RemoveListenerCancelActionEvent(Action listener) => _onCancelActionHandler -= listener;


    }
}