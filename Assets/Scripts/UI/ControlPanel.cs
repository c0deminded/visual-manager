using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{

    public Text time;


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
