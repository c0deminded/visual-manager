using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDataRepresentation : MonoBehaviour
{

    public RepresentationObject buildingFormation;
    public RepresentationObject parentBuildingRepresentation;

    RepresentationManager manager;
    MapRepresentation mainMapRepr;

    public void Init(MapRepresentation parentMap)
    {
        manager = GameManager.Instance.representationManager;
        mainMapRepr = parentMap;
    }

    void OnMouseUp()
    {

    }

    public void OnClickOnBuilding()
    {

    }



}
