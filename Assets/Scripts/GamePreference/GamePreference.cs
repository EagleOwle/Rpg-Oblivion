using UnityEngine;

public class GamePreference : ScriptableObject
{
    #region Singleton
    private static GamePreference instance;
    public static GamePreference Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load("GamePreference") as GamePreference;

                if (instance == null)
                {
                    Debug.LogError("GamePreference Instance is null");
                }

            }

            return instance;
        }
    }
    #endregion

    public ApplicationSetting applicationSetting;

}

