using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSfxManager : MonoBehaviour
{
    [SerializeField] private AudioClip stepClip;
    [SerializeField] private AudioSource audioSource;

    private float playTime;
    private const float playPause = 0.5f;
    private bool isPlay = false;

    public void PlayStep()
    {
        if(isPlay == false) 
            StartCoroutine(Play());
    }

    public void StopPlayStep()
    {
        StopAllCoroutines();
        isPlay = false;
    }

    private IEnumerator Play()
    {
        isPlay = true;
        while(true)
        {
            if (playTime < Time.time)
            {
                audioSource.pitch = Random.Range(0.5f, 0.8f);
                audioSource.PlayOneShot(stepClip);
                playTime = Time.time + playPause;
            }
            else
            {
                isPlay = false;
                break;
            }

            yield return null;
        }
    }

}
