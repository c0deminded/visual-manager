using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public RepresentationManager representationManager;
    public LoadingIndicatorCanvas loadingIndicator;
    public DataManager datManager;
    public MyInputManager inputManager;

    public bool fingerIsOverUI = false;

    bool isDecoratingNow;

    void Awake()
    {
        Application.targetFrameRate = 60;
        Instance = this;
        loadingIndicator.DisableLoadingIndicator();
    }

    void Update()
    {
        CheckIfFingerIsOnUI();
    }

    public IEnumerator DecorateCoroutineWithSwitcher(IEnumerator coroutine)
    {
        Instance.loadingIndicator.InitLoadingIndicator();
        SwitchingCanvas switcher = Instantiate(CommonAssets.CommonAssetsInstance.representationSwitcherCanvas).GetComponent<SwitchingCanvas>();

        yield return new WaitForSeconds(0.5f);
        if (coroutine != null)
            yield return StartCoroutine(coroutine);

        Instance.loadingIndicator.DisableLoadingIndicator();
        switcher.DisableSelf();

        yield break;
    }

    public IEnumerator DecorateActionWithSwitcher(UnityAction action)
    {
        Instance.loadingIndicator.InitLoadingIndicator();
        SwitchingCanvas switcher = Instantiate(CommonAssets.CommonAssetsInstance.representationSwitcherCanvas).GetComponent<SwitchingCanvas>();

        yield return new WaitForSeconds(0.5f);
        if (action != null)
            action.Invoke();

        Instance.loadingIndicator.DisableLoadingIndicator();
        switcher.DisableSelf();

        yield break;
    }

    PointerEventData m_PointerEventData;
    public void CheckIfFingerIsOnUI()
    {
        m_PointerEventData = new PointerEventData(EventSystem.current);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();

        //рейкастим по всем слотам пула
        results = new List<RaycastResult>();
        GraphicRaycaster[]raycasters = FindObjectsOfType<GraphicRaycaster>();
        foreach (GraphicRaycaster r in raycasters)
        {
            if (r.gameObject.activeInHierarchy && r.isActiveAndEnabled)
            {
                r.Raycast(m_PointerEventData, results);
                if (results.Count > 0)
                {
                    fingerIsOverUI = true;
                    return;
                }
            }
        }
        fingerIsOverUI = false;
    }

}
