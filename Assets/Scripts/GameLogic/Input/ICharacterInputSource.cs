using UnityEngine;

namespace GameLogic.Input
{
    public interface ICharacterInputSource
    {
        bool AttackInputDown { get; }
        bool AttackInput { get; }
        Vector2 MouseInput { get; }
    }
}