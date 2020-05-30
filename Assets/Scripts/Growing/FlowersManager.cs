using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlowersManager : MonoBehaviour
{
    public Flower[] flowerObjects;
    List<FlowerData> flowers;

    private void Start()
    {
        HideAll();
    }

    public void ShowUp(List<FlowerData> flowers)
    {
        this.flowers = flowers;
        StartCoroutine(ShowFlowers());
    }

    private IEnumerator ShowFlowers()
    {
        HideAll();
        flowers.OrderBy(f => f.Height);
        for(int i = 0; i < flowers.Count; i++)
        {
            if(i < flowerObjects.Length)
            {
                flowerObjects[i].ShowUp(flowers[i]);
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                Debug.LogError("There are more flowers in the level data that can be dislayed.");
            }
        }
    }

    private void HideAll()
    {
        foreach (var tulip in flowerObjects)
        {
            tulip.transform.localScale = Vector3.zero;
        }
    }
}
