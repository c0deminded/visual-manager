using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] List<BoxCollider> limitColliderList;
    [SerializeField] float inertia;
    [SerializeField] LayerMask layerMaskForBaseCollider;
    [SerializeField] LayerMask layerMaskForLimits;

    [SerializeField] Collider movementBase;
    [SerializeField] Camera currentCamera;
    bool lockMovement = false;

    public void Init(Camera cam, Collider baseMovementPlane = null)
    {
        if (cam != null)
            currentCamera = cam;
        currentCamera = cam;
        if (baseMovementPlane != null)
            movementBase = baseMovementPlane;
    }

    public void SetLock(bool isLocked)
    {
        lockMovement = isLocked;
    }

    void LateUpdate()
    {
        MoveUpdate();
    }


    Vector3 currentMovementVector;
    Vector3 prevScreenPointOfRaycast;
    Vector3 inertiaVector;
    RaycastHit hit;
    RaycastHit hit2;
    bool movePerformed = false;

    void MoveUpdate()
    {
        if (!lockMovement) // movement screen space
            if (Input.GetMouseButton(0))
            {
                if (Physics.Raycast(currentCamera.ScreenPointToRay(Input.mousePosition), out hit, 3000, layerMaskForBaseCollider.value))
                {
                    Physics.Raycast(currentCamera.ScreenPointToRay(prevScreenPointOfRaycast), out hit2, 3000, layerMaskForBaseCollider.value);
                    currentMovementVector = hit.point - hit2.point;
                    prevScreenPointOfRaycast = Input.mousePosition;

                    if (!movePerformed)
                    {
                        movePerformed = true;
                    }
                    else
                    {
                        Collider[] limitHits = Physics.OverlapSphere(currentCamera.transform.position - currentMovementVector, 0.5f, layerMaskForLimits.value);
                        if (limitHits.Length == 0)
                        {
                            currentCamera.transform.position = currentCamera.transform.position - currentMovementVector;
                        }
                    }
                }
            }
            else
            {
                if (movePerformed)
                    inertiaVector = currentMovementVector;
                movePerformed = false;
                prevScreenPointOfRaycast = Vector3.zero;
                transform.position -= inertiaVector * Time.deltaTime * inertia;
                inertiaVector = Vector3.Lerp(inertiaVector, Vector3.zero, Time.timeScale);
            }




    }







}
