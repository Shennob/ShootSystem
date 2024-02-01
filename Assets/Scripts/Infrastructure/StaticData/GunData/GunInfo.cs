using UnityEngine;

namespace Infrastructure.StaticData.GunData
{
    [CreateAssetMenu(fileName = "GunInfo", menuName = "StaticData/Gun")]
    public class GunInfo : ScriptableObject
    {
        [Header("Base Settings")]
        public GunName GunName;
        public GunType GunType;
        [Header("Ammo Settings")]
        public int MaxAmmo;
        public float ReloadTime;
        public GameObject Bullet;
        public GameObject BulletHolePrefab;
        [Header("Spread Settings")]
        public float Spreading;
        [Header("Recoil Settings")]
        public Vector3 Recoil;
        public float Snappiness;
        public float ReturnSpeed;
        public float DelayPerShoot;
    }
}