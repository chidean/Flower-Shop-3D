using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GrowingCanvas : MonoBehaviour
{
    public GameManager gameManager;
    public RectTransform fertilize;
    public RectTransform water;
    public RectTransform cut;
    public RectTransform heightBar;
    public RectTransform hintBar;
    public RectTransform barPanel;

    public void HideFertilize()
    {
        TweenOut(fertilize);
    }
    public void HideWater()
    {
        TweenOut(water);
    }
    public void HideCut()
    {
        TweenOut(cut);
        StartCoroutine(TweenHeightBar(tweenIn: false));
    }

    internal void ReadyToSetHeight()
    {
        StartCoroutine(TweenHeightBar(tweenIn: true));
        var pos = barPanel.anchoredPosition;
        pos.y = -200;
        barPanel.anchoredPosition = pos;
        var tween = barPanel.DOAnchorPosY(82, 1);
        tween.SetEase(Ease.OutBack);
        tween.SetDelay(0.5f);
    }

    void TweenOut(RectTransform obj)
    {
        var tween = obj.DOAnchorPosY(-200, 1);
        tween.SetEase(Ease.InBack);
    }

    IEnumerator TweenHeightBar(bool tweenIn)
    {
        yield return new WaitForSeconds(1);
        var pos = tweenIn ? -230 : 0;
        var tween = barPanel.DOAnchorPosX(pos, 1);
        tween.SetEase(Ease.OutBack);
    }

    public void SetHint(float normalizedHeight)
    {
        float height = 190f + (normalizedHeight * 371.72f);
        hintBar.sizeDelta = new Vector2(hintBar.sizeDelta.x, height);
    }

    public void UpdateHeightBar(float normalizedHeight)
    {
        float height = 190f + normalizedHeight * 369;
        heightBar.sizeDelta = new Vector2(heightBar.sizeDelta.x, height);
    }
}
