using System.Linq;
using Infrastructure.Logic.PlayerSpawner;
using Infrastructure.StaticData.Level;
using Infrastructure.StaticData.Player;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LevelStaticData levelData = (LevelStaticData)target;

            if (GUILayout.Button("Collect"))
            {
                levelData.PlayerSpawner =
                    FindObjectsOfType<PlayerSpawnMarker>()
                        .Select(x => new PlayerSpawnerData(x.transform.position))
                        .Single();
                
                levelData.LevelKey = SceneManager.GetActiveScene().name;
            }
            
            EditorUtility.SetDirty(target);
        }
    }
}