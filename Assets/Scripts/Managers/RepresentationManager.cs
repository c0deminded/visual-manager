using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepresentationManager : MonoBehaviour
{
   
    [Header("Representations")]
    public RepresentationObject buildingsRepresentation;
    public RepresentationObject hierarchyRepresentation;

    [Header("UI")]
    public SwitchButton switchReprButtons;

    RepresentationObject currentRepresentation = null;

    void Start()
    {
        OpenRepresentation(buildingsRepresentation);
        UnityAction[] actions = new UnityAction[2];
        actions[0] = () =>
        {
            if (currentRepresentation != buildingsRepresentation)
                GameManager.Instance.StartCoroutine(
    GameManager.Instance.DecorateActionWithSwitcher(() => OpenRepresentation(buildingsRepresentation)));
        };
        actions[1] = () =>
        {
            if (currentRepresentation != hierarchyRepresentation)
                GameManager.Instance.StartCoroutine(
GameManager.Instance.DecorateActionWithSwitcher(() => OpenRepresentation(hierarchyRepresentation)));
        };

        switchReprButtons.InitActions(actions, 0);

        SetDefaultState();
    }

    public void OpenRepresentation(RepresentationObject repr)
    {
        if (currentRepresentation != null)
        {
            GameManager.Instance.loadingIndicator.InitLoadingIndicator();
            currentRepresentation.CloseRepresentation();
        }
        currentRepresentation = repr;
        currentRepresentation.OpenRepresentation();
        GameManager.Instance.loadingIndicator.DisableLoadingIndicator();
    }

    void SetDefaultState()
    {
        hierarchyRepresentation.gameObject.SetActive(true);
    }



}
