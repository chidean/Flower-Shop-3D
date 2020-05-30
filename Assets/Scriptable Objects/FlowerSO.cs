using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateFlower", order = 1)]
public class FlowerSO : ScriptableObject
{
    public string Name;
    public GameObject PistilPrefab;
    public Sprite ImageIcon;
    public int Reward;
    [Range(0, 1)]
    public float Height;
    public Vector3[] rotationRanges = new Vector3[] { Vector3.zero };

    internal Vector3 GetPreferedRotation()
    {
        var newRot = Vector3.zero;
        if (Random.value > 0.5f)
        {
            newRot = new Vector3(0, Random.Range(340, 380), 0);
        }
        else
        {
            newRot = new Vector3(0, Random.Range(160, 200), 0);
        }
        return newRot;
    }
}
