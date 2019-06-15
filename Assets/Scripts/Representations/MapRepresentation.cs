using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRepresentation : RepresentationObject
{

    [SerializeField] List<BuildingDataRepresentation> childRepresentations;

    void Awake()
    {
        if (childRepresentations != null)
            foreach (BuildingDataRepresentation rep in childRepresentations)
            {
                rep.Init(this);
            }
    }


    public override void OpenRepresentation(RepresentationObject parent)
    {
        base.OpenRepresentation();
    }




}
