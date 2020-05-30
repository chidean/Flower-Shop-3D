using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Spawner : MonoBehaviour
{
    public GameObject[] spawnable;
    public Transform container;
    public float interval = 0.2f;

    SphereCollider colider;
    private void Awake()
    {
        colider = GetComponent<SphereCollider>();
    }

    public void Spawn()
    {
        enabled = true;
        StartCoroutine(Instantiate());
    }

    // Update is called once per frame
    IEnumerator Instantiate()
    {
        while (isActiveAndEnabled)
        {
            GameObject prefab = spawnable[Random.Range(0, spawnable.Length)];
            var spawnee = Instantiate(prefab, GetRandomPos(), Random.rotation, container);

            spawnee.transform.eulerAngles = transform.eulerAngles;
            yield return new WaitForSeconds(interval);
        }
    }

    private Vector3 GetRandomPos()
    {
        var randomPos = transform.position + Random.insideUnitSphere * colider.radius;
        return new Vector3(randomPos.x, randomPos.y, transform.position.z);
    }
}
