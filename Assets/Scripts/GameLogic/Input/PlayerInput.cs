using UnityEngine;

namespace GameLogic.Input
{
    public class PlayerInput : MonoBehaviour, ICharacterInputSource
    {
        public bool AttackInputDown { get; private set; }
        public bool AttackInput { get; private set; }
        public Vector2 MouseInput { get; private set; }
    
        private void Update() => 
            ReadInput();

        private void ReadInput()
        {
            AttackInputDown = UnityEngine.Input.GetMouseButtonDown(0);
            AttackInput = UnityEngine.Input.GetMouseButton(0);
            MouseInput = GetMouseInput();
        }

        private Vector2 GetMouseInput() => 
            new(UnityEngine.Input.GetAxis("Mouse X"), UnityEngine.Input.GetAxis("Mouse Y"));
    }
}