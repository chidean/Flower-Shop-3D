using System.Collections;
using UnityEngine;

public class AnimatedObj : MonoBehaviour
{
    public float animatonDuration = 2.2f;

    TweenObj bag;
    Animation shaking;
    Spawner spawner;

    private void Awake()
    {
        bag = GetComponentInChildren<TweenObj>();
        shaking = GetComponentInChildren<Animation>();
        spawner = GetComponentInChildren<Spawner>();
        StopFertilizing();
    }

    public void ShowUp()
    {
        StopAllCoroutines();
        bag.TweenIn(onComplete: StartShaking);
    }

    private void StartShaking()
    {
        shaking.Play();
        spawner.Spawn();
        StartCoroutine(StopShaking());
    }

    private IEnumerator StopShaking()
    {
        yield return new WaitForSeconds(animatonDuration);
        spawner.enabled = false;
        bag.TweenOut(onComplete: StopFertilizing);
    }

    private void StopFertilizing()
    {
        shaking.Stop();
        spawner.enabled = false;
        bag.gameObject.SetActive(false);
    }
}
