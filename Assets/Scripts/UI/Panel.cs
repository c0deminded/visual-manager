using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{

    [SerializeField] RectTransform panel;
    [SerializeField] Button controlButton;
    [SerializeField] Image onArrow;
    [SerializeField] Image offArrow;

    [SerializeField] Vector3 activePos;
    [SerializeField] Vector3 inactivePos;
    Vector3 currentTargetPos;
    public bool isActiveNow = false;

    void Start()
    {
        controlButton.onClick.AddListener(SwitchState);
        currentTargetPos = inactivePos;
        onArrow.gameObject.SetActive(false);
        offArrow.gameObject.SetActive(true);
    }

    public void SwitchState()
    {
        if (isActiveNow)
        {
            currentTargetPos = inactivePos;
            onArrow.gameObject.SetActive(false);
            offArrow.gameObject.SetActive(true);
        }
        else
        {
            currentTargetPos = activePos;
            onArrow.gameObject.SetActive(true);
            offArrow.gameObject.SetActive(false);
        }
        isActiveNow = !isActiveNow;
    }

    void Update()
    {
        panel.anchoredPosition = Vector3.Lerp(panel.anchoredPosition, currentTargetPos, Time.deltaTime * 8);
    }


}
