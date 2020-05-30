using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateLevel", order = 1)]
public class LevelSO : ScriptableObject
{
    [Range(1, 5)]
    public int OrderedNumberOfFlowers;
    [Range(1, 5)]
    public int WrongNumberOfFlowers;
    public FlowerSO[] orderedFlowers;
    public FlowerSO[] wrongFlowers;

    public List<FlowerData> pickedFlowers = new List<FlowerData>();
}
