using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public VaseSO vaseType;

    internal void MoveOut(Vector3 farOffPoint)
    {
        var tween = transform.DOMove(farOffPoint, 1);
        tween.onComplete = DestroyVase;
    }

    internal void MoveToCenter()
    {
        var centerPoint = transform.localPosition;
        centerPoint.x = 0;
        centerPoint.z = 0;
        var tween = transform.DOLocalMove(centerPoint, 1);
    }
    private void DestroyVase()
    {
        Destroy(gameObject);
    }
}
