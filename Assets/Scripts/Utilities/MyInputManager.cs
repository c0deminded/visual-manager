using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInputManager : MonoBehaviour
{

    public bool canClickOnItems = false;





}

public interface IClickable
{
    void OnClick();
}
