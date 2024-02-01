using Infrastructure.Services;
using Infrastructure.StaticData.GunData;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        void CreatePlayer(Vector3 at);
        void CreateHud();
        void CreateBullet(GunInfo gunInfo, Vector3 position, Vector3 point);
        void CreateBulletHole(GunInfo gunInfo, Vector3 point, Vector3 normal);
    }
}