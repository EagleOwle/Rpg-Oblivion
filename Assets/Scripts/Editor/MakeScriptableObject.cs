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

    [MenuItem("Assets/Create/ConfigStorage")]
    public static void CreateConfigStorage()
    {
        ConfigStorage asset = ScriptableObject.CreateInstance<ConfigStorage>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/ConfigStorage.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

}
