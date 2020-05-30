using System;
using UnityEngine;

public class ArrangeManager : MonoBehaviour
{
    public static readonly Vector2 rangeX = new Vector2(-1.8f, 2.1f);
    public static ArrangeManager Instance { get; private set; }

    [HideInInspector]
    public VaseSO chosenVase;
    public DropFlowerSpawner spawner;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GeneralManager.Instance.Status = GameStatus.Cut;
    }

    internal void ChoseVase(VaseSO vaseType)
    {
        chosenVase = vaseType;
        spawner.StartSpawning(GeneralManager.Instance.currentLevel.pickedFlowers);
    }
}
