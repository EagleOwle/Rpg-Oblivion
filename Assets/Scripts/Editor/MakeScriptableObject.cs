using UnityEngine;
using UnityEditor;

public class MakeScriptableObject : MonoBehaviour
{
    [MenuItem("Assets/Create/GamePreference")]
    public static void CreateGamePreference()
    {
        GamePreference asset = ScriptableObject.CreateInstance<GamePreference>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/GamePreference.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/PrefabsStorage")]
    public static void CreatePrefabsStorage()
    {
        PrefabsStorage asset = ScriptableObject.CreateInstance<PrefabsStorage>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/PrefabsStorage.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

}
