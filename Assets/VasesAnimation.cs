using UnityEngine;
using DG.Tweening;

public class VasesAnimation : MonoBehaviour
{
    public Vase[] vases;

    public void AnimateChosenVase(Transform chosenVase)
    {
        DisperseOtherVases(chosenVase);
    }

    private void DisperseOtherVases(Transform chosenVase)
    {
        foreach (var vase in vases)
        {
            if (vase.transform != chosenVase)
            {
                Disperse(vase);
            }
            else
            {
                vase.MoveToCenter();
            }
        }
    }

    private void Disperse(Vase vase)
    {
        var heading = vase.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        var farOffPoint = direction * 20;

        vase.MoveOut(farOffPoint);
    }
}
