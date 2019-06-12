using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrderAndLayer_MeshRend : MonoBehaviour
{

    [SerializeField] string layer;
    [SerializeField] int order = 0;

    
    void Start()
    {
        SetLayer();
    }

    [ContextMenu("SetLayers")]
    void SetLayer()
    {
        GetComponent<Renderer>().sortingLayerName = layer;
        GetComponent<Renderer>().sortingOrder = order;
    }


}
