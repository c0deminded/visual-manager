using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDataRepresentation : MonoBehaviour, IClickable
{

    public RepresentationObject buildingFormation;
    public RepresentationObject parentBuildingRepresentation;
    public BusinessUnit myBusinessUnit;

    [SerializeField] Transform selectionTransform;
    [SerializeField] Transform[] dataCubes;
    [SerializeField] Image[] dataCircles;

    MapRepresentation mainMapRepr;

    [HideInInspector] public bool isSelected = false;

    public void Init(MapRepresentation parentMap)
    {
        mainMapRepr = parentMap;
        HideDataCubes();
        foreach (Image im in dataCircles)
            im.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        OnClickOnBuilding();
    }

    public void OnClickOnBuilding()
    {
        mainMapRepr.DeselectAll();
        SetSelection(!isSelected);
        if(myBusinessUnit)
        InspectorManager.Instance.Show(myBusinessUnit);
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
            dataCubes[i].transform.localScale = Vector3.zero;
            dataCubes[i].GetComponentInChildren<MeshRenderer>().material.color = colors[i];
            SpriteTweeners.SpriteScaleCrossFromVectorToVector(this, dataCubes[i], new Vector3(1, 1, 0.01f), new Vector3(1, 1, sizes[i]), 0.35f, i * 0.1f);
        }
    }

    public void ShowDataCircles(Color[] colors, float[] values)
    {
        foreach (var t in dataCircles)
            t.gameObject.SetActive(false);
        for (int i = 0; i < values.Length; i++)
        {
            dataCircles[i].gameObject.SetActive(true);
            dataCircles[i].fillAmount = 0;
            dataCircles[i].color = colors[i];
            StartCoroutine(FillCircle(dataCircles[i],0, values[i], 0.5f, i * 0.11f));
        }
    }

    IEnumerator FillCircle(Image im,float startValue, float targetValue, float time, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        float t = 0;
        float speed = 1 / time;
        while(t < 1)
        {
            im.fillAmount = Mathf.Lerp(startValue, targetValue, t);
            t += Time.deltaTime * speed;
            yield return null;
        }
        im.fillAmount = targetValue;
        yield break;
    }

    public void HideDataCubes()
    {
        foreach (Transform t in dataCubes)
            t.gameObject.SetActive(false);
    }

    public void HideDataCircles()
    {
        for (int i = 0; i < dataCircles.Length; i++)
        {
            StartCoroutine(FillCircle(dataCircles[i],dataCircles[i].fillAmount, 0, 0.5f, i * 0.11f));
        }
    }

}
