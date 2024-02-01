using Data;
using GameLogic;
using GameLogic.Gun;
using Infrastructure.AssetManagement;
using Infrastructure.StaticData.GunData;
using Ui.HudElements;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        private GameObject _player;

        public GameFactory(IAssets assets) => 
            _assets = assets;

        public void CreatePlayer(Vector3 at)
        {
            _player = _assets.Instantiate(ResourcesPath.PlayerPrefabPath, at);
            _player.GetComponentInChildren<Gun>().Construct(this);
        }

        public void CreateBullet(GunInfo gunInfo, Vector3 position, Vector3 point)
        {
            GameObject bullet = _assets.Instantiate(gunInfo.Bullet, position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Init((point - position).normalized);
        }

        public void CreateBulletHole(GunInfo gunInfo, Vector3 point, Vector3 normal)
        {
            GameObject newHole = _assets.Instantiate(
                gunInfo.BulletHolePrefab,
                point + normal * Constants.BulletHoleViewDistance,
                Quaternion.identity);
            newHole.transform.LookAt(point + normal);
        }

        public void CreateHud()
        {
            GameObject hud = _assets.Instantiate(ResourcesPath.HudPrefabPath);
            hud.GetComponent<GunInfoView>().Construct(_player);
        }
    }
}