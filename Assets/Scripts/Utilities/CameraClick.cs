using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraClick : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] LayerMask mask;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    RaycastHit hit;
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && GameManager.Instance.inputManager.canClickOnItems && !GameManager.Instance.fingerIsOverUI)
        {
            Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit,3000, mask.value);
            if(hit.collider != null)
            if (hit.collider.GetComponent<IClickable>() != null)
                hit.collider.GetComponent<IClickable>().OnClick();
        }
    }

}
