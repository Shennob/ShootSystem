using UnityEngine;

namespace GameLogic.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class Looking : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity;

        private readonly Vector2 _clampAngle = new(-90f, 90f);
        private MonoBehaviour _inputSourceBehaviour;
        private ICharacterInputSource _inputSource;
        private float _yRotation;
        private float _xRotation;

        private void Awake()
        {
            _inputSourceBehaviour = GetComponent<PlayerInput>();
            _inputSource = (ICharacterInputSource)_inputSourceBehaviour;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update() => 
            Move();

        private void Move()
        {
            float mouseX = _inputSource.MouseInput.x * _mouseSensitivity * Time.deltaTime;
            float mouseY = _inputSource.MouseInput.y * _mouseSensitivity * Time.deltaTime;

            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, _clampAngle.x, _clampAngle.y);
        
            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        }
    }
}