using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TDChart : MonoBehaviour
{
    Text valueText; 
    public float value= 0f; 
    public float lerpSpeed = 6f;
    RectTransform rt;
    float random;
    
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        valueText = GetComponentInChildren<Text>();
        random = Random.Range(0f, 315f);
    }

    public void Regenerate()
    {
        value = 0;
        random = Random.Range(0f, 315f);
    }

    // Update is called once per frame
    void Update()
    {
        rt.sizeDelta = new Vector2(47f,Mathf.Lerp(rt.sizeDelta.y,random , Time.deltaTime * lerpSpeed));
        value = Mathf.Lerp(value, random, Time.deltaTime * lerpSpeed);
        valueText.text = ((int)((value)*100/315f)).ToString();
    }

}
