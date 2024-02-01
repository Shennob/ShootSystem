using Data;
using Infrastructure.StaticData.GunData;
using UnityEngine;

namespace GameLogic.GunTips
{
    public class Spread
    {
        private float _remainingRecoilTime;
        private readonly GunInfo _gunInfo;
        private readonly Transform _gunCamera;
    
        public Spread(GunInfo gunInfo, Transform gunCamera)
        {
            _gunInfo = gunInfo;
            _gunCamera = gunCamera;
        }

        public Vector3 CreateSpread()
        {
            Vector3 cameraPosition = _gunCamera.position;
        
            Vector3 spread = cameraPosition + _gunCamera.forward * Constants.SpreadMultiplier;
            spread += Random.Range(-_gunInfo.Spreading, _gunInfo.Spreading) * _gunCamera.up;
            spread += Random.Range(-_gunInfo.Spreading, _gunInfo.Spreading) * _gunCamera.right;
            spread -= cameraPosition;
            spread.Normalize();

            return spread;
        }
    }
}
