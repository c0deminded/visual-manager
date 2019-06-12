using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TweenUIElement : MonoBehaviour {

    public static UITweeners UiTweeners = new UITweeners();
    [SerializeField] AnimationCurve scaleCurve;
    [SerializeField] Transform scalableSprite;
    [SerializeField] Image [] allImages;
    [SerializeField] bool autoDetectImages;
    [SerializeField] Text[] allTexts;
    [SerializeField] bool autoDetectTexts;
    [SerializeField] float appearTime = 0.3f;
    [SerializeField] float disappearTime = 0.2f;
    [SerializeField] float defaultSpriteScale = 1;
    [SerializeField] float disableScale = 0.01f;

    void Start()
    {
        //defaultSpriteScale = scalableSprite.localScale.x;
    }

    void OnEnable()
    {
        StopAllCoroutines();
        if (autoDetectImages)
            allImages = transform.GetComponentsInChildren<Image>();
        foreach (Image im in allImages)
        {
            UiTweeners.ImAlphaCrossFromValueToValue(this, im, 0, im.color.a, appearTime / 2f);
        }
        if (autoDetectTexts)
            allTexts = transform.GetComponentsInChildren<Text>();
        foreach (Text t in allTexts)
        {
            UiTweeners.TextCrossFromValueToValue(this, t, 0, t.color.a, appearTime);
        }
        SpriteTweeners.SpriteScaleViaCurve(this, scalableSprite, scaleCurve, defaultSpriteScale, appearTime);
    }

    public void EnableSelf()
    {
        StopAllCoroutines();
        gameObject.SetActive(true);
        StopAllCoroutines();
        foreach (Image im in allImages)
        {
            UiTweeners.ImAlphaCrossFromValueToValue(this, im, 0, im.color.a, appearTime / 2f);
        }
        if (autoDetectTexts)
            allTexts = transform.GetComponentsInChildren<Text>();
        foreach (Text t in allTexts)
        {
            UiTweeners.TextCrossFromValueToValue(this, t, 0, t.color.a, appearTime);
        }
        SpriteTweeners.SpriteScaleViaCurve(this, scalableSprite, scaleCurve, defaultSpriteScale, appearTime);
    }

    public void DisableSelf(bool disableGO = false, bool destroyGO = false)
    {
        if (!gameObject.activeInHierarchy)
            return;
        StopAllCoroutines();

        if (autoDetectImages)
            allImages = transform.GetComponentsInChildren<Image>();

        foreach (Image im in allImages)
        {
            UiTweeners.ImAlphaCrossFromValueToValue(this, im, im.color.a, 0, disappearTime);
        }
        foreach (Text t in allTexts)
        {
            UiTweeners.TextCrossFromValueToValue(this, t, t.color.a, 0, disappearTime);
        }
        SpriteTweeners.SpriteScaleCrossFromValueToValue(this, scalableSprite, scalableSprite.localScale.x, disableScale, disappearTime);
        if (disableGO)
            StartCoroutine(DisableProcess(destroyGO));
    }

    IEnumerator DisableProcess(bool destroy)
    {
        yield return new WaitForSeconds(disappearTime + 0.2f);
        if (destroy)
            Destroy(gameObject);
        else
            gameObject.SetActive(false);
        yield break;
    }

}
