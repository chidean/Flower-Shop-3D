using DG.Tweening;
using UnityEngine;


public class Scissors : MonoBehaviour
{
    public Vector3 showedPos;

    public Transform left;
    public Transform right;

    bool animating = true;

    private void Awake()
    {
        Snip(stayClosed : true);
    }

    public void UpdateHeight(float normalizedHeight)
    {
        if (!animating)
        {
            var inverted = 1 - normalizedHeight;
            var pos = transform.localPosition;
            pos.y = -0.27f - (inverted * 0.43f);
            transform.localPosition = pos;
        }
    }

    public void ShowUp()
    {
        var tween = transform.DOLocalMove(showedPos, 0.68f);
        tween.SetEase(Ease.OutCirc);
        tween.onComplete = Open;
    }

    internal void ReadyToDragAndDrop()
    {
        GetComponent<DragScissors>().enabled = true;
    }

    private void Open()
    {
        var openPos = new Vector3(0, 20, 0);
        left.DOLocalRotate(openPos, 0.3f).SetEase(Ease.OutBack);
        var tween = right.DOLocalRotate(-openPos, 0.3f);
        tween.SetEase(Ease.OutBack);
        tween.onComplete = AnimComplete;
    }

    private void AnimComplete()
    {
        animating = false;
    }

    public void Snip(bool stayClosed = false)
    {
        left.DOLocalRotate(Vector3.zero, 0.3f).SetEase(Ease.InBack);
        var tween = right.DOLocalRotate(Vector3.zero, 0.3f);
        tween.SetEase(Ease.OutBack);
        if (!stayClosed)
        {
            tween.onComplete = Open;
        }
    }
}
