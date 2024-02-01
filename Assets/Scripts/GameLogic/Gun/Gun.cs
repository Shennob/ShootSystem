using Infrastructure.Factory;
using Infrastructure.StaticData.GunData;
using UnityEngine;

namespace GameLogic.Gun
{
    [RequireComponent(typeof(Clip))]
    public abstract class Gun : MonoBehaviour
    {
        [Header("Gun Settings")] 
        [SerializeField] protected GunInfo GunInfo;

        [Header("Shoot Settings")]
        [SerializeField] protected Transform ShootPoint;
        
        protected Clip Clip;
        protected float RemainingTimePerShoot;
       
        private IGameFactory _gameFactory;

        public GunType Type => GunInfo.GunType;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            Clip = GetComponent<Clip>();
        }

        private void Update() => 
            TimerPerShoot();

        public abstract void Use();

        protected void PlayShootEffects(Vector3 point, Vector3 normal)
        {
            var shootPosition = ShootPoint.transform.position;
            _gameFactory.CreateBullet(GunInfo, shootPosition, point);
            _gameFactory.CreateBulletHole(GunInfo, point, normal);
        }

        private void TimerPerShoot()
        {
            if (!(RemainingTimePerShoot > 0))
                return;

            RemainingTimePerShoot -= Time.deltaTime;
            if (RemainingTimePerShoot <= 0)
            {
                RemainingTimePerShoot = 0;
            }
        }
    }
}