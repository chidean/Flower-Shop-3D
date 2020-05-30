using UnityEngine;

public class FlowerCreator : MonoBehaviour
{
    public Transform pistil;

    public void Create(GameObject pistilPrefab)
    {
        Debug.Log("crate " + pistilPrefab.name);
        Instantiate(pistilPrefab, pistil, false);
    }
}
