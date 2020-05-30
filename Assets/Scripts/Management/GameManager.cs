using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public AnimatedObj fertilizer;
    public AnimatedObj water;
    public GrowingCanvas growingCanvas;
    public FlowersManager flowers;
    public Scissors scissors;
    public HeightManager heightManager;
    LevelSO levelData => GeneralManager.Instance.currentLevel;

    GameStatus status
    {
        get => GeneralManager.Instance.Status;
        set { GeneralManager.Instance.Status = value; }
    }
    float orderedHeight;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartGame();
        //Invoke("ShowFlowers", 0.05f);
        //Invoke("ShowScissors", 0.1f);
    }

    public void StartGame()
    {
        status = GameStatus.Unfertilized;
    }

    public void Fertilize()
    {
        if (status == GameStatus.Unfertilized)
        {
            growingCanvas.HideFertilize();
            status = GameStatus.Fertilized;
            fertilizer.ShowUp();
        }
    }

    public void Water()
    {
        if (status == GameStatus.Fertilized)
        {
            growingCanvas.HideWater();
            status = GameStatus.Watered;
            water.ShowUp();
            Invoke("ShowFlowers", 4);
        }
    }

    public void ShowFlowers()
    {
        Debug.Log("ShowFlowers");
        var generator = new FlowesGenerator();
        var randomFlowers = generator.GenerateRandomFlowers(levelData);
        orderedHeight = generator.CorrentHeight;
        flowers.ShowUp(randomFlowers);
        Debug.Log("Invoke ShowScissors");
        Invoke("ShowScissors", 4);
    }

    void ShowScissors()
    {
        Debug.Log("ShowScissors");
        status = GameStatus.Grown;
        heightManager.enabled = true;
        growingCanvas.ReadyToSetHeight();
        growingCanvas.SetHint(orderedHeight);
        scissors.ShowUp();
    }

    public void SetHeight()
    {
        if (status == GameStatus.Grown)
        {
            heightManager.enabled = false;
            growingCanvas.HideCut();
            status = GameStatus.HeightSet;
            scissors.ReadyToDragAndDrop();
        }
    }

    public void CutFlower(FlowerData flowerData)
    {
        levelData.pickedFlowers.Add(flowerData);

        CheckIfGrowingIsOver();
    }

    private void CheckIfGrowingIsOver()
    {
        int numberOfCorrectCutFlowers = 0;
        foreach (var cutFlower in levelData.pickedFlowers)
        {
            bool isOrderedType = levelData.orderedFlowers.Contains(cutFlower.FlowerType);
            if (isOrderedType)
            {
                numberOfCorrectCutFlowers++;
            }
        }
        if (numberOfCorrectCutFlowers == levelData.OrderedNumberOfFlowers)
        {
            GeneralManager.Instance.ChooseVase();
        }
    }
}
