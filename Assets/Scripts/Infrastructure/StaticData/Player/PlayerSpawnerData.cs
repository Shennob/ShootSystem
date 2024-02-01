using System;
using UnityEngine;

namespace Infrastructure.StaticData.Player
{
    [Serializable]
    public class PlayerSpawnerData
    {
        public Vector3 Position;

        public PlayerSpawnerData(Vector3 position)
        {
            Position = position;
        }
    }
}