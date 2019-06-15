using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepresentationObject : MonoBehaviour, IRepresentationObject
{

    public GameObject myGameObject;
    public Color ambientLightingColor;
    public float ambientIntencity;

    RepresentationObject parentRepresentation;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    public virtual void OpenRepresentation(RepresentationObject parent = null)
    {
        myGameObject.SetActive(true);
        RenderSettings.ambientLight = ambientLightingColor;
        RenderSettings.ambientIntensity = ambientIntencity;
        // todo if parent != null
    }

    public virtual void CloseRepresentation()
    {
        myGameObject.SetActive(false);
    }

}

public interface IRepresentationObject
{
    void OpenRepresentation(RepresentationObject parent = null);
    void CloseRepresentation();
}
