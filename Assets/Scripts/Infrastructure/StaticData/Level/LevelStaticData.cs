using Infrastructure.StaticData.Player;
using UnityEngine;

namespace Infrastructure.StaticData.Level
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public PlayerSpawnerData PlayerSpawner;
    }
}