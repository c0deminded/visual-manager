using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorManager : MonoBehaviour
{

    public Text unitName;
    public Text unitDesc;

    public static InspectorManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void Show(BusinessUnit unit)
    {
        unitName.text = unit.naming;
        unitDesc.text = unit.desc;
    }
}
