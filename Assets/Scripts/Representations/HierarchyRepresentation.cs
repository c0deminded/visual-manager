using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HierarchyRepresentation : RepresentationObject
{

    [SerializeField] Button showDepartmentsButton;
    [SerializeField] GameObject canvasWithDepartments;
    [SerializeField] GameObject[] canvasesWithBosses;
    UITweeners myTweeners = new UITweeners();

    bool departmentsAreShown = false;

    void Start()
    {
        showDepartmentsButton.onClick.RemoveAllListeners();
        showDepartmentsButton.onClick.AddListener(ShowDepartments);
    }

    public void ShowDepartments()
    {
        StopAllCoroutines();
        if (!departmentsAreShown)
        {
            canvasWithDepartments.gameObject.SetActive(true);

            myTweeners.ArrayImageAlphaCrossFromValueToValue(this, canvasWithDepartments.GetComponentsInChildren<Image>().ToList(), 0, 0.3f, 0.35f);
            myTweeners.ArrayTextAlphaCrossFromValueToValue(this, canvasWithDepartments.GetComponentsInChildren<Text>().ToList(), 0, 1, 0.35f);

            foreach (GameObject go in canvasesWithBosses)
            {
                go.gameObject.SetActive(true);
                myTweeners.ArrayImageAlphaCrossFromValueToValue(this, go.GetComponentsInChildren<Image>().ToList(), 0, 1, 0.35f);
                myTweeners.ArrayTextAlphaCrossFromValueToValue(this, go.GetComponentsInChildren<Text>().ToList(), 0, 1, 0.35f);
            }
        }
        else
        {
            myTweeners.ArrayImageAlphaCrossFromValueToValue(this, canvasWithDepartments.GetComponentsInChildren<Image>().ToList(), 0.3f, 0, 0.35f);
            myTweeners.ArrayTextAlphaCrossFromValueToValue(this, canvasWithDepartments.GetComponentsInChildren<Text>().ToList(), 1, 0, 0.35f);

            foreach (GameObject go in canvasesWithBosses)
            {
                myTweeners.ArrayImageAlphaCrossFromValueToValue(this, go.GetComponentsInChildren<Image>().ToList(), 1, 0, 0.35f);
                myTweeners.ArrayTextAlphaCrossFromValueToValue(this, go.GetComponentsInChildren<Text>().ToList(), 1, 0, 0.35f);
            }
        }

        departmentsAreShown = !departmentsAreShown;
        showDepartmentsButton.targetGraphic.color = departmentsAreShown ? GameManager.Instance.datManager.activeButtonColor : GameManager.Instance.datManager.buttonColor;
    }



}
