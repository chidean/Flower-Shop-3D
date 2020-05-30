using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class TweenObj : MonoBehaviour
{
    Vector3 startingRotation = new Vector3(0, 0, 50);
    float startingPosX = -1;
    float endPosX = 0;
    float duration = 0.5f;

    public void TweenIn(TweenCallback onComplete)
    {
        DOTween.Kill(transform);
        gameObject.SetActive(true);
        transform.localPosition = new Vector3(startingPosX, 0, 0);
        transform.DOLocalMoveX(endPosX, duration);
        transform.localEulerAngles = startingRotation;
        var tween = transform.DOLocalRotate(new Vector3(0, 0, 0), duration, RotateMode.Fast);
        tween.onComplete = onComplete;
    }

    public void TweenOut(TweenCallback onComplete)
    {
        DOTween.Kill(transform);
        transform.DOLocalMoveX(startingPosX, duration);
        var tween = transform.DOLocalRotate(startingRotation, duration, RotateMode.Fast);
        tween.onComplete = onComplete;
    }
}
