using Infrastructure.StaticData.GunData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic.GunTips
{
    public class Recoil : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
    
        private Vector3 _targetRotation;
        private Vector3 _currentRotation;
        private GunInfo _gunInfo;

        private void Update() => 
            Move();

        public void SetRandomDirection(GunInfo gunInfo)
        {
            _gunInfo = gunInfo;
            _targetRotation += new Vector3(gunInfo.Recoil.x,
                Random.Range(-gunInfo.Recoil.y, gunInfo.Recoil.y),
                Random.Range(-gunInfo.Recoil.z, gunInfo.Recoil.z));
        }

        private void Move()
        {
            if (_gunInfo == null)
                return;
        
            _targetRotation = Vector3.Lerp(
                _targetRotation, 
                Vector3.zero, 
                _gunInfo.ReturnSpeed * Time.deltaTime);
        
            _currentRotation = Vector3.Slerp(
                _currentRotation, 
                _targetRotation, 
                _gunInfo.Snappiness * Time.fixedDeltaTime);
        
            _camera.localRotation = Quaternion.Euler(_currentRotation);
            transform.localRotation = Quaternion.Euler(_currentRotation);
        }
    }
}