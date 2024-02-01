using GameLogic.Input;
using Infrastructure.StaticData.GunData;
using UnityEngine;

namespace GameLogic.Gun
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerHand : MonoBehaviour
    {
        [SerializeField] private Gun _currentGun;
    
        private MonoBehaviour _inputSourceBehaviour;
        private ICharacterInputSource _inputSource;

        private void Awake()
        {
            _inputSourceBehaviour = GetComponent<PlayerInput>();
            _inputSource = (ICharacterInputSource)_inputSourceBehaviour;
        }

        private void Update()
        {
            switch (_currentGun.Type)
            {
                case GunType.Single:
                    AttackDown();
                    break;
                case GunType.Automatic:
                    Attack();
                    break;
            }
        }

        private void AttackDown()
        {
            if (_inputSource.AttackInputDown)
                _currentGun.Use();
        }

        private void Attack()
        {
            if (_inputSource.AttackInput)
                _currentGun.Use();
        }
    }
}
