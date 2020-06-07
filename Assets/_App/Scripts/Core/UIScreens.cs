using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "UIScreens", menuName = "ScriptableObjects/UIScreens", order = 1)]
public class UIScreens : ScriptableObject
{
    public UIScreenReference[] screens;
}

[Serializable]
public class UIScreenReference
{
    public string name;
    public AssetReferenceGameObject asset; 
}