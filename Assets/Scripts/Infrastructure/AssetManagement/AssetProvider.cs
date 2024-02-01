using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public class AssetProvider : IAssets
    {
        public GameObject Instantiate(string path)
        {
            GameObject prefab = LoadPrefab(path);
            
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 position)
        {
            GameObject prefab = LoadPrefab(path);
            
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }

        public GameObject Instantiate(GameObject template, Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(template, position, rotation);
        }

        private static GameObject LoadPrefab(string path) => 
            Resources.Load<GameObject>(path);
    }
}