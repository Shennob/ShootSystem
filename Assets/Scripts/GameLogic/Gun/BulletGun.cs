using Data;
using GameLogic.GunTips;
using UnityEngine;

namespace GameLogic.Gun
{
    [RequireComponent(typeof(Recoil))]
    public class BulletGun : Gun
    {
        [SerializeField] private Transform _gunCamera;

        private Recoil _recoil;
    
        private void Start() =>
            _recoil = GetComponent<Recoil>();

        public override void Use() =>
            Shoot();

        private void Shoot()
        {
            if (Clip.CanShoot == false)
                return;

            if (RemainingTimePerShoot <= 0)
            {
                ThrowRaycast();
                _recoil.SetRandomDirection(GunInfo);
                Clip.DecreaseAmmo();
            }
        }

        private void ThrowRaycast()
        {
            var spread = new Spread(GunInfo, _gunCamera);

            Vector3 newDirection = spread.CreateSpread();
            Vector3 point = ShootPoint.position + newDirection * Constants.RaycastDistance;
            Vector3 normal = -newDirection;

            Ray ray = new Ray(_gunCamera.position, newDirection);
            if (Physics.Raycast(ray, out var hit, Constants.RaycastDistance))
            {
                point = hit.point;
                normal = hit.normal;
            }

            PlayShootEffects(point, normal);

            RemainingTimePerShoot = GunInfo.DelayPerShoot;
        }
    }
}