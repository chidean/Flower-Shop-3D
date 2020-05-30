using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightManager : MonoBehaviour
{
    public static readonly Vector2 heightRange = new Vector2(-0.27f, 0.16f);
    public GeneralManager gm;
    public Scissors scissors;
    public GrowingCanvas canvas;

    float fluctuatingBar = 0;
    bool goingUp = true;

    private void Start()
    {
        gm = GeneralManager.Instance;
    }

    private void Update()
    {
        if (gm.Status == GameStatus.Grown)
        {
            scissors.UpdateHeight(fluctuatingBar);
            canvas.UpdateHeightBar(fluctuatingBar);
            if (goingUp)
            {
                fluctuatingBar += Time.deltaTime;
            }
            else
            {
                fluctuatingBar -= Time.deltaTime;
            }
            if (fluctuatingBar >= 1)
            {
                goingUp = false;
            }
            else if (fluctuatingBar <= 0)
            {
                goingUp = true;
            }
        }
    }
}
