using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorManager : MonoBehaviour
{

    [SerializeField] Text unitName;
    [SerializeField] Text unitDesc;
    [SerializeField] Text time;

    [SerializeField] SwitchButton actionsStatsButton;
    [SerializeField] GameObject[] statsAndActions; 

    public static InspectorManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        UnityEngine.Events.UnityAction [] actions = new UnityEngine.Events.UnityAction[2];
        actions[0] = () => { SwitchStatsAndActions(true); };
        actions[1] = () => { SwitchStatsAndActions(false); };
        actionsStatsButton.InitActions(actions, 0);
    }

    void Update()
    {
        UpdateTime();
    }

    public void Show(BusinessUnit unit)
    {
        unitName.text = unit.naming;
        unitDesc.text = unit.desc;
    }

    void UpdateTime()
    {
        int minutes = System.DateTime.Now.Minute;
        int hours = System.DateTime.Now.Hour;

        time.text = (hours > 9 ? hours.ToString() : "0" + hours.ToString()) + ":" +
                (minutes > 9 ? minutes.ToString() : "0" + minutes.ToString());
    }

    #region actions and stats

    public void SwitchStatsAndActions(bool isActions)
    {
        statsAndActions[0].SetActive(isActions);
        statsAndActions[1].SetActive(!isActions);
    }

    #endregion

}
