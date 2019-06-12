using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepresentationObject : MonoBehaviour, IRepresentationObject
{

    public GameObject myGameObject;
    public Color ambientLightingColor;
    public float ambientIntencity;

    public virtual void OpenRepresentation()
    {
        myGameObject.SetActive(true);
        RenderSettings.ambientLight = ambientLightingColor;
        RenderSettings.ambientIntensity = ambientIntencity;
    }

    public virtual void CloseRepresentation()
    {
        myGameObject.SetActive(false);
    }

}

public interface IRepresentationObject
{
    void OpenRepresentation();
    void CloseRepresentation();
}
