using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorManager : MonoBehaviour
{

    public Text unitName;
    public Text unitDesc;
    public Text time;

    public static InspectorManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void Show(BusinessUnit unit)
    {
        unitName.text = unit.naming;
        unitDesc.text = unit.desc;
    }


    void Update()
    {
        UpdateTime();
    }


    void UpdateTime()
    {
        int minutes = System.DateTime.Now.Minute;
        int hours = System.DateTime.Now.Hour;

        time.text = (hours > 9 ? hours.ToString() : "0" + hours.ToString()) + ":" +
                (minutes > 9 ? minutes.ToString() : "0" + minutes.ToString());
    }

}
