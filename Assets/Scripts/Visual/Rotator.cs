using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public Vector3 rotationVector;

    void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
