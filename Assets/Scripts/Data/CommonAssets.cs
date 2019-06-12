using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAssets : ScriptableObject
{

    public static CommonAssets CommonAssetsInstance
    {
        get
        {
            if (commonAssetsInstance == null)
                commonAssetsInstance = Resources.Load("CommonAssets") as CommonAssets;
            return commonAssetsInstance;
        }
    }
    private static CommonAssets commonAssetsInstance;

    [Header("Representation Switcher")]
    public GameObject representationSwitcherCanvas;


}
