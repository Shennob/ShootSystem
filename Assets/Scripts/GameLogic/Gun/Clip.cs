using System;
using System.Collections;
using Infrastructure.StaticData.GunData;
using UnityEngine;

namespace GameLogic.Gun
{
    public class Clip : MonoBehaviour
    {
        [SerializeField] private GunInfo _gunInfo;
    
        private int _currentAmmo;
        private WaitForSeconds _dilay;
        private bool _canShoot = true;

        public bool CanShoot => _canShoot;

        public event Action<GunName,int> AmmoChanged;

        private void Awake() => 
            _dilay = new WaitForSeconds(_gunInfo.ReloadTime);

        private void Start()
        {
            _currentAmmo = _gunInfo.MaxAmmo;
            ChangeMaxAmmoCount();
        }
    
        public void DecreaseAmmo()
        {
            _currentAmmo--;
        
            if (_currentAmmo == 0)
            {
                StartCoroutine(Reloading());
            }
        
            ChangeMaxAmmoCount();
        }

        private IEnumerator Reloading()
        {
            _canShoot = false;
            yield return _dilay;

            _currentAmmo = _gunInfo.MaxAmmo;
            ChangeMaxAmmoCount();
            _canShoot = true;
        }
    
        private void ChangeMaxAmmoCount() => 
            AmmoChanged?.Invoke(_gunInfo.GunName ,_currentAmmo);
    }
}