using System.Collections.Generic;
using UnityEngine;

public class DropFlowerSpawner : MonoBehaviour
{
    public GameObject prefab;
    List<FlowerData> flowers;
    public FlowerSO[] testFlowers;

    public void StartSpawning(List<FlowerData> flowers)
    {
        this.flowers = flowers;
        if (flowers.Count == 0)
        {
            foreach (var flower in testFlowers)
            {
                flowers.Add(new FlowerData() { FlowerType = flower });
            }
        }

        Spawn(flowers[0]);
    }

    private void Spawn(FlowerData data)
    {
        Debug.Log("Spawn " + data.FlowerType.name);
        var flower = Instantiate(prefab, transform, false);
        flower.GetComponent<FlowerCreator>().Create(data.FlowerType.PistilPrefab);

        var randomPosX = Mathf.Lerp(ArrangeManager.rangeX.x, ArrangeManager.rangeX.y, Random.value);
        flower.transform.localPosition = new Vector3(randomPosX, 0);
    }
}
