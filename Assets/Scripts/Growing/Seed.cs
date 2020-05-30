using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Seed : Spawnee
{
    private void Awake()
    {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(new Vector3(Random.value + 1, 0, 0), ForceMode.Impulse);
        var initialScale = transform.localScale.x;
        transform.localScale = Vector3.one * Random.Range(initialScale / 2, initialScale);
    }
}
