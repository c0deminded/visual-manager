using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] bool isPermanent = false; 
    [SerializeField] Button[] buttons;
    [SerializeField] RectTransform selector;
    [SerializeField] Vector2[] anchoredPositions;

    UnityAction[] actionOnClick;
    int currentState = 0;

    public void InitActions(UnityAction [] actions, int state = 0)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(actions[i]);
            int a = i;
            buttons[i].onClick.AddListener(() => { SwitchVisualState(a); });
        }
        currentState = state;
        SwitchVisualState(state);
    }

    public void SwitchVisualState(int stateNumber)
    {
        currentState = stateNumber;
        if (isPermanent)
            selector.anchoredPosition = anchoredPositions[stateNumber];
    }

    void Update()
    {
        if (!isPermanent)
        {
            selector.anchoredPosition = Vector2.Lerp(selector.anchoredPosition, anchoredPositions[currentState], Time.deltaTime * 10);
        }
    }

}
