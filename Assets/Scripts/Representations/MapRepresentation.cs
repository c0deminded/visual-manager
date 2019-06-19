    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapRepresentation : RepresentationObject
{

    [SerializeField] List<BuildingDataRepresentation> childRepresentations;
    [SerializeField] Button showCubesButton;
    [SerializeField] Button showCirclesButton;
    [SerializeField] RectTransform helpersContainer;
    [SerializeField] Vector3 helpersInactivePos;
    [SerializeField] Vector3 helpersActivePos;
    [SerializeField] Image[] dataImages;
    [SerializeField] Image[] dataImagesContainers;
    [SerializeField] Text[] dataTexts;

    Vector3 currentTargetPosForHelpers;
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
        helpersContainer.anchoredPosition = helpersInactivePos;
        currentTargetPosForHelpers = helpersInactivePos;
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
        ManageHelpers();
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
        ManageHelpers();
    }

    void ManageHelpers(int count = 5)
    {
        for (int i = 0; i < dataImagesContainers.Length; i++)
        {
            dataImagesContainers[i].gameObject.SetActive(true);
        }
        if (circlesAreShown || cubesAreShown)
        {
            currentTargetPosForHelpers = helpersActivePos;
        }
        else
        {
            currentTargetPosForHelpers = helpersInactivePos;
        }
        for (int i =0; i < count; i++)
        {
            dataImages[i].color = GameManager.Instance.datManager.dataColors[i];
            dataTexts[i].text = GameManager.Instance.datManager.dataValuesDescription[i];
        }
        for (int i = 0; i < dataImagesContainers.Length; i++)
        {
            if (i >= count)
                dataImagesContainers[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        helpersContainer.anchoredPosition = Vector3.Lerp(helpersContainer.anchoredPosition, currentTargetPosForHelpers, Time.deltaTime * 10);
    }

    #endregion;



}
