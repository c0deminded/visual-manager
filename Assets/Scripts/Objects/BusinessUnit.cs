using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BusinessUnit : MonoBehaviour, ISelectable
{
    // Some common shit of all childs
    public string naming;
    public string desc;

    public void Select()
    {
        InspectorManager.Instance.Show(this);
    }

    //and another useless shit
}
