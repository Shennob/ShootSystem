﻿using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 position);
        GameObject Instantiate(GameObject template, Vector3 position, Quaternion rotation);
    }
}