using System.Collections.Generic;
using UnityEngine;

public class FlowesGenerator
{
    LevelSO levelData;
    List<FlowerData> returnedList = new List<FlowerData>();

    public float CorrentHeight { get; private set; }

    public List<FlowerData> GenerateRandomFlowers(LevelSO level)
    {
        CorrentHeight = Random.value;
        levelData = level;
        AddCorrectChoices();
        AddWrongChoices();
        return returnedList;
    }

    private void AddCorrectChoices()
    {
        for (int i = 0; i < levelData.OrderedNumberOfFlowers; i++)
        {
            var flowerData = CreateFlowerData(levelData.orderedFlowers);
            flowerData.Height = CorrentHeight;
            returnedList.Add(flowerData);
        }
    }

    private void AddWrongChoices()
    {
        for (int i = 0; i < levelData.WrongNumberOfFlowers; i++)
        {
            returnedList.Add(CreateFlowerData(levelData.wrongFlowers));
        }
    }

    private FlowerData CreateFlowerData(FlowerSO[] types)
    {
        return new FlowerData()
        {
            Height = Random.value,
            FlowerType = types[Random.Range(0, types.Length)]
        };
    }
}
