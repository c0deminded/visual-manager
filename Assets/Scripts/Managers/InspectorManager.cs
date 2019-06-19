using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InspectorManager : MonoBehaviour
{

    [SerializeField] Text unitName;
    [SerializeField] Text unitDesc;
    [SerializeField] Text [] timeTexts;

    [SerializeField] SwitchButton actionsStatsButton;
    [SerializeField] GameObject[] statsAndActions;
    [SerializeField] GameObject statsAndActionsContainer;
    [SerializeField] Panel myPanel;
    [SerializeField] Panel mainControlPanel;
    [SerializeField] TDChart[] tdchart;

    public static InspectorManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        UnityEngine.Events.UnityAction [] actions = new UnityEngine.Events.UnityAction[2];
        actions[0] = () => { SwitchStatsAndActions(true); };
        actions[1] = () => { SwitchStatsAndActions(false); };
        actionsStatsButton.InitActions(actions, 0);
        actions[0].Invoke();

        myPanel.AddActionToButton(new UnityAction(()=> 
        {
            if(GameManager.Instance.representationManager.currentRepresentation == GameManager.Instance.representationManager.buildingsRepresentation)
            (GameManager.Instance.representationManager.buildingsRepresentation as MapRepresentation).DeselectAll();
        }));
    }

    void Update()
    {
        UpdateTime();
    }

    public void Show(BusinessUnit unit)
    {
        unitName.text = unit.naming;
        unitDesc.text = unit.desc;
        if (!myPanel.isActiveNow)
            myPanel.SwitchState();
        if (mainControlPanel.isActiveNow)
            mainControlPanel.SwitchState();
        foreach (var item in tdchart)
        {
            item.Regenerate();
        }
        #region crutch
        if (unit is MockUnit)
            statsAndActionsContainer.SetActive(false);
        else
            statsAndActionsContainer.SetActive(true);
        #endregion
    }

    void UpdateTime()
    {
        int minutes = System.DateTime.Now.Minute;
        int hours = System.DateTime.Now.Hour;

        string s = (hours > 9 ? hours.ToString() : "0" + hours.ToString()) + ":" +
                (minutes > 9 ? minutes.ToString() : "0" + minutes.ToString());
        foreach (Text t in timeTexts)
        {
            t.text = s;
        }
    }

    #region actions and stats

    public void SwitchStatsAndActions(bool isActions)
    {
        statsAndActions[0].SetActive(isActions);
        statsAndActions[1].SetActive(!isActions);
    }

    #endregion

}
