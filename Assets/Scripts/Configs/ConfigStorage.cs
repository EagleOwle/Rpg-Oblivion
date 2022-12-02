using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigStorage : ScriptableObject
{
    #region Singleton
    private static ConfigStorage instance;
    public static ConfigStorage Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load("ConfigStorage") as ConfigStorage;

                if (instance == null)
                {
                    Debug.LogError("ConfigStorage Instance is null");
                }

            }

            return instance;
        }
    }
    #endregion

    public ConfigItemStorage configItem;
    public Prefabs prefabs;

    private void OnValidate()
    {
#if UNITY_EDITOR
        for (int i = 0; i < configItem.configsWeapon.Count; i++)
        {
            configItem.configsWeapon[i].index = i;

            if (configItem.configsWeapon[i].weaponPrefab != null)
            {
                configItem.configsWeapon[i].name = configItem.configsWeapon[i].weaponPrefab.name;
            }
            else
            {
                configItem.configsWeapon[i].name = "Empty";
            }
        }
#endif
    }

}
