using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float targetZpos;

    void Awake()
    {
        targetZpos = transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, targetZpos);
    }

}
