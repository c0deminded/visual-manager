using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingIndicatorCanvas : MonoBehaviour
{

    [SerializeField] Image[] circles;
    [SerializeField] float[] rotationSpeed;
    bool isActive = true;

    public void InitLoadingIndicator()
    {
        if (isActive)
            return;
        StopAllCoroutines();
        for (int i = circles.Length -1; i >= 0; i--)
        {
            SpriteTweeners.SpriteScaleCrossFromValueToValue(this, circles[i].transform, 0, 1, 0.21f, 0.05f * i);
        }
        isActive = true;
    }

    public void DisableLoadingIndicator(float delay = 0.5f)
    {
        if (!isActive)
            return;
        StopAllCoroutines();
        StartCoroutine(DisableLoadingIndicatorProcess(delay));
    }

    IEnumerator DisableLoadingIndicatorProcess(float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < circles.Length; i++)
        {
            SpriteTweeners.SpriteScaleCrossFromValueToValue(this, circles[i].transform, 1, 0, 0.12f, 0.05f * i);
        }
        isActive = false;
        yield break;
    }


    void Update()
    {
        for (int i = 0; i < circles.Length; i++)
        {
            circles[i].transform.Rotate(Vector3.forward * rotationSpeed[i] * Time.deltaTime);
        }
    }

}
