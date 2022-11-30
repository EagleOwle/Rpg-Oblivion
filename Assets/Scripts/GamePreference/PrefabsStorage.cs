using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsStorage : ScriptableObject
{
    #region Singleton
    private static PrefabsStorage instance;
    public static PrefabsStorage Instance
    {
        get
        {
            if(instance == null)
            {
                instance = Resources.Load("PrefabsStorage") as PrefabsStorage;

                if (instance == null)
                {
                    Debug.LogError("PrefabsStorage Instance is null");
                }

            }

            return instance;
        }
    }
    #endregion

    public Sword sword; 
    public Staff staff; 
    public Mase mase; 

}
