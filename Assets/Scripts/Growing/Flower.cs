using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public Transform leftLeaf;
    public Transform rightLeaf;
    public Transform leafContainer;
    public Transform pistil;
    public Transform dottedLine;

    Ease ease = Ease.OutCirc;
    float endScale;
    FlowerData flower;

    public void ShowUp(FlowerData flower)
    {
        this.flower = flower;
        Initialize();
        SetHeight(flower.Height);

        StartCoroutine(ScaleUp());

        RotateFlower();
        RotatePistil();
    }

    public void Cut()
    {
        GameManager.Instance.CutFlower(flower);
        var tween = transform.DOLocalMoveY(6, 1);
        tween.onComplete = DestroyFlower;
    }

    private void Initialize()
    {
        dottedLine.localScale = new Vector3(0, 1, 1);
        pistil.localScale = Vector3.zero;

        Instantiate(flower.FlowerType.PistilPrefab, pistil, false);
    }

    private void SetHeight(float height)
    {
        endScale = 0.75f + height / 4;
        var pos = leafContainer.localPosition;
        leafContainer.localPosition = new Vector3(pos.x, 0.3f * height, pos.z);
    }

    IEnumerator ScaleUp()
    {
        ScaleUp(transform);
        ScaleUp(rightLeaf);
        yield return new WaitForSeconds(0.3f);
        ScaleUp(leftLeaf);
        yield return new WaitForSeconds(0.3f);
        ScaleUp(pistil);
        yield return new WaitForSeconds(1f);
        ShowDottedLine();
    }

    private void ShowDottedLine()
    {
        dottedLine.eulerAngles = Vector3.zero;
        var tween = dottedLine.DOScaleX(1, 1);
        tween.SetEase(ease);
    }

    private void RotateFlower()
    {
        var randomRotation = Random.Range(340, 380);
        var newRot = new Vector3(0, randomRotation, 0);
        if (Random.value > 0.5f)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        var tween = transform.DOLocalRotate(newRot, 1, RotateMode.LocalAxisAdd);
        tween.SetEase(ease);
    }

    private void RotatePistil()
    {
        pistil.eulerAngles = new Vector3(0, 50, 0);
        var pivot = pistil.GetComponentInChildren<Pistil>()?.pivot;
        if (pivot == null)
        {
            pivot = pistil;
        }
        var tween = pivot.DORotate(new Vector3(0, 180, 0), 1, RotateMode.LocalAxisAdd);
        tween.SetEase(ease);
        tween.SetDelay(0.4f);
    }

    void ScaleUp(Transform obj)
    {
        obj.localScale = Vector3.zero;
        var tween = obj.DOScale(Vector3.one * endScale, 1);
        tween.SetEase(ease);
    }

    private void DestroyFlower()
    {
        Destroy(gameObject);

    }
}
