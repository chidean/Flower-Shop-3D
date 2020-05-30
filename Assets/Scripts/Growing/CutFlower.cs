using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CutFlower : MonoBehaviour
{
    public GameObject stemPrefab;
    BoxCollider bounds;

    private void Awake()
    {
        bounds = GetComponent<BoxCollider>();
    }

    public void Cut(Vector3 cutPoint)
    {
        PlaceStub(cutPoint);

        bounds.enabled = false;
        var flower = GetComponent<Flower>();
        flower.Cut();
    }

    private void PlaceStub(Vector3 cutPoint)
    {
        var stub = Instantiate(stemPrefab, transform.parent);
        stub.transform.localPosition = transform.localPosition;
        var newScale = StubHeight(cutPoint, stub);
        stub.transform.localScale = new Vector3(1, newScale, 1);
    }

    float StubHeight(Vector3 cutPoint, GameObject stub)
    {
        var cutPointY = stub.transform.InverseTransformPoint(cutPoint).y;
        var stubHeight = stub.GetComponent<BoxCollider>().size.y;
        return cutPointY / stubHeight;
    }
}
