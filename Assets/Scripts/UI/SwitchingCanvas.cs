using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingCanvas : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void DisableSelf()
    {
        anim.SetTrigger("SwitchBack");
        Destroy(gameObject, 2);
    }


}
