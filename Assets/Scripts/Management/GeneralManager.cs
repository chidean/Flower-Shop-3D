using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager Instance { get; private set; }
    public LevelSO currentLevel;
    public GameStatus Status { get; set; }
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Instance = this;
    }

    internal void ChooseVase()
    {
        StartCoroutine(WaitAndSwitchScenes());
    }

    private IEnumerator WaitAndSwitchScenes()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Arrange");
    }
}
