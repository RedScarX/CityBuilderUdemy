using UnityEngine;

namespace CityBuilder
{
    public abstract class PlayerState
    {
        protected GameManager GameManager;

        public PlayerState(GameManager gameManager)
        {
            GameManager = gameManager;
        }
        
        public abstract void OnInputPointerDown(Vector3 position);
        public abstract void OnInputPointerChange(Vector3 position);
        public abstract void OnInputPanChange(Vector3 position);
        public abstract void OnInputPanUpChange();
        public abstract void OnInputPointerUp();
        
        public virtual void EnterState(){}
        public abstract void Cancel();
    }
}