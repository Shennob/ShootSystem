using GameLogic.Gun;
using Infrastructure.StaticData.GunData;
using TMPro;
using UnityEngine;

namespace Ui.HudElements
{
    public class GunInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gunNameText;
        [SerializeField] private TMP_Text _ammoText;

        private Clip _clip;
    
        public void Construct(GameObject player)
        {
            _clip = player.GetComponentInChildren<Clip>();
            _clip.AmmoChanged += OnAmmoChanged;
        }

        private void OnDisable() => 
            _clip.AmmoChanged -= OnAmmoChanged;

        private void OnAmmoChanged(GunName gunName, int count)
        {
            _gunNameText.text = gunName.ToString();
            _ammoText.text = count.ToString();
        }
    }
}
