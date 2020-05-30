using UnityEngine;

public class Spawnee : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -1.5)
        {
            Destroy(gameObject);
        }
    }
}
