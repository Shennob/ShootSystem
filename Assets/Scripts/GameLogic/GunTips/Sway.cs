using UnityEngine;

namespace GameLogic.GunTips
{
    public class Sway : MonoBehaviour
    {
        [SerializeField] private float _swayAmount = 0.04f;
        [SerializeField]private float _maxSwayAmount = 0.06f;
        [SerializeField]private float _swaySmoothValue = 0.04f;
    
        private Vector3 _initialSwayPosition;

        private void Start() => 
            _initialSwayPosition = transform.localPosition;

        private void LateUpdate()
        {
            Vector2 clampPosition = new Vector2(GetClamp(GetAxis().x), GetClamp(GetAxis().y));
            Vector3 finalSwayPosition = new Vector3(clampPosition.x, clampPosition.y, 0);
        
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                finalSwayPosition + _initialSwayPosition,
                _swaySmoothValue);
        }

        private float GetClamp(float direction) => 
            Mathf.Clamp(direction, -_maxSwayAmount, _maxSwayAmount);

        private Vector2 GetAxis()
        {
            return new Vector2(-UnityEngine.Input.GetAxisRaw("Mouse X") * _swayAmount, 
                -UnityEngine.Input.GetAxisRaw("Mouse Y") * _swayAmount);
        }
    }
}