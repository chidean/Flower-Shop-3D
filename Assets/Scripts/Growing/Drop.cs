using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Drop : Spawnee
{
    void Awake()
    {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddTorque(new Vector3(0, 5 + Random.value, 0));

        transform.localScale = Vector3.zero;
        var scale = Random.Range(0.3f, 0.7f);
        transform.DOScale(Vector3.one * scale, 0.2f);
        transform.DOLocalRotate(Vector3.zero, 2f);
    }
}
