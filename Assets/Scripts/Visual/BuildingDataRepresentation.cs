using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDataRepresentation : MonoBehaviour, IClickable
{

    public RepresentationObject buildingFormation;
    public RepresentationObject parentBuildingRepresentation;

    [SerializeField] Transform selectionTransform;
    [SerializeField] Transform[] dataCubes;

    RepresentationManager manager;
    MapRepresentation mainMapRepr;

    [HideInInspector] public bool isSelected = false;

    public void Init(MapRepresentation parentMap)
    {
        manager = GameManager.Instance.representationManager;
        mainMapRepr = parentMap;
        HideDataCubes();
    }

    public void OnClick()
    {
        OnClickOnBuilding();
    }

    public void OnClickOnBuilding()
    {
        SetSelection(!isSelected);
    }

    public void SetSelection(bool isSelected)
    {
        Debug.Log("Selecting");
        if (!this.isSelected && isSelected)
        {
            selectionTransform.gameObject.SetActive(true);
            SpriteTweeners.SpriteScaleCrossFromValueToValue(this, selectionTransform, 0, 1, 0.35f);
        }
        if(this.isSelected && !isSelected)
        {
            SpriteTweeners.SpriteScaleCrossFromValueToValue(this, selectionTransform, 1, 0, 0.35f);
        }
        this.isSelected = isSelected;
    }

    public void ShowDataCubes(Color[] colors, float[] sizes)
    {
        foreach (Transform t in dataCubes)
            t.gameObject.SetActive(false);
        for (int i = 0; i < sizes.Length; i++)
        {
            dataCubes[i].gameObject.SetActive(true);
            dataCubes[i].GetComponent<MeshRenderer>().material.color = colors[i];
            SpriteTweeners.SpriteScaleCrossFromVectorToVector(this, dataCubes[i], new Vector3(1, 0, 1), new Vector3(1, sizes[i], 1), 0.5f);
        }
    }

    public void HideDataCubes()
    {
        foreach (Transform t in dataCubes)
            t.gameObject.SetActive(false);
    }

}
