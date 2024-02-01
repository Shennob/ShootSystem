using System.Collections.Generic;
using System.Linq;
using Data;
using Infrastructure.StaticData.Level;
using Infrastructure.StaticData.Player;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<string, LevelStaticData> _levels;

        public void Load()
        {
            _levels = Resources
                .LoadAll<LevelStaticData>(ResourcesPath.LevelDataPath)
                .ToDictionary(x => x.LevelKey, x => x);
        }

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData levelData)
                ? levelData
                : null;
    }
}