using System;
using Infrastructure.StaticData.Level;
using UnityEngine.SceneManagement;

namespace Data
{
    public static class DataExtensions
    {
        public static LevelId GetCurrentLevelId()
        {
            Enum.TryParse(SceneManager.GetActiveScene().name, true, out LevelId activeScene);

            return activeScene;
        }
    }
}