using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSfxManager : MonoBehaviour
{
    [SerializeField] private AudioClip stepClip;
    [SerializeField] private AudioSource audioSource;

    private float playTime;
    private const float playPause = 0.5f;

    public void PlayStep()
    {
        StopAllCoroutines();
        StartCoroutine(Play());
    }

    public void StopPlayStep()
    {
        StopAllCoroutines();
    }

    private IEnumerator Play()
    {
        while(true)
        {
            if (playTime < Time.time)
            {
                audioSource.pitch = Random.Range(0.5f, 0.8f);
                audioSource.PlayOneShot(stepClip);
                playTime = Time.time + playPause;
            }

            yield return null;
        }
    }

}
