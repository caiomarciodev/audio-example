using UnityEditor;
using UnityEngine;

namespace ZombieToys.Scripts.WeaponShop
{
    public class MakeWeaponObject
    {
        [MenuItem("Assets/Create/Weapon Object")]
        public static void Create()
        {
            WeaponObject asset = ScriptableObject.CreateInstance<WeaponObject>();
            AssetDatabase.CreateAsset(asset, "Assets/ZombieToys/Weapons/NewWeaponObject.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}