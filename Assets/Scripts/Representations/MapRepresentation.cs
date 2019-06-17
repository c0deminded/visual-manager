using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapRepresentation : RepresentationObject
{

    [SerializeField] List<BuildingDataRepresentation> childRepresentations;
    [SerializeField] Button showCubesButton;
    [SerializeField] Button showCirclesButton;

    bool circlesAreShown = false;
    bool cubesAreShown = false;

    void Awake()
    {
        if (childRepresentations != null)
            foreach (BuildingDataRepresentation rep in childRepresentations)
            {
                rep.Init(this);
            }
        showCubesButton.onClick.AddListener(ShowCubes);
        showCirclesButton.onClick.AddListener(ShowCircles);
    }


    public override void OpenRepresentation(RepresentationObject parent)
    {
        base.OpenRepresentation();
    }


    public void DeselectAll()
    {
        foreach (BuildingDataRepresentation rep in childRepresentations)
        {
            rep.SetSelection(false);
        }
    }

    #region data stufff

    public void ShowCubes()
    {
        if (!cubesAreShown)
        {
            foreach (BuildingDataRepresentation rep in childRepresentations)
            {
                int a = Random.Range(1, 6);
                float[] valuesArray = new float[a];
                for (int i = 0; i < valuesArray.Length; i++)
                {
                    valuesArray[i] = Random.Range(0.1f, 1);
                }
                rep.ShowDataCubes(GameManager.Instance.datManager.dataColors, valuesArray);
            }
        }
        else
        {
            foreach (BuildingDataRepresentation rep in childRepresentations)
            {
                rep.HideDataCubes();
            }
        }
        cubesAreShown = !cubesAreShown;
        showCubesButton.targetGraphic.color = cubesAreShown ? GameManager.Instance.datManager.activeButtonColor : GameManager.Instance.datManager.buttonColor;
    }

    public void ShowCircles()
    {
        if (!circlesAreShown)
        {
            foreach (BuildingDataRepresentation rep in childRepresentations)
            {
                int a = Random.Range(1, 5);
                float[] valuesArray = new float[a];
                for (int i = 0; i < valuesArray.Length; i++)
                {
                    valuesArray[i] = Random.Range(0.1f, 1);
                }
                rep.ShowDataCircles(GameManager.Instance.datManager.dataColors, valuesArray);
            }
        }
        else
        {
            foreach (BuildingDataRepresentation rep in childRepresentations)
            {
                rep.HideDataCircles();
            }
        }
        circlesAreShown = !circlesAreShown;
        showCirclesButton.targetGraphic.color = circlesAreShown? GameManager.Instance.datManager.activeButtonColor : GameManager.Instance.datManager.buttonColor;
    }


    #endregion;



}
