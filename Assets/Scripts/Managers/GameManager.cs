using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public RepresentationManager representationManager;
    public LoadingIndicatorCanvas loadingIndicator;
    bool isDecoratingNow;

    void Awake()
    {
        Instance = this;
        loadingIndicator.DisableLoadingIndicator();
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

}
